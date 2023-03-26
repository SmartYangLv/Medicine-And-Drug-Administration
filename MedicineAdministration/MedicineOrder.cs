using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicineAdministration
{
    public partial class MedicineOrder : Form
    {
        private string _No;
        private DataTable MedicineTable;
        private DataTable MedicineOrderTable;
        private DataView MedicineView;
        private int pagesize;
        private int currentpage;
        private int maxpagesize;
        public MedicineOrder()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public MedicineOrder(string No):this()
        {
            this ._No = No;
        }
        private void RefreshRowFilter()
        => this.MedicineView .RowFilter =                                                                
                $"RowID >{(this.currentpage  - 1) * this.pagesize } " +
                $"AND RowID <={this.currentpage  * this.pagesize }";
        private void MedicineOrder_Load(object sender, EventArgs e)
        {
            this.pagesize = 10;
            this.currentpage = 1;
            SqlConnection sqlConnection =new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1 .Connection = sqlConnection;
            sqlCommand .Connection = sqlConnection;
            sqlCommand.CommandText =
                $@"SELECT NO AS 编号, MedicineName AS 药品名称,PINYIN
         ,MedicineClassify AS 药品类型,Specification AS 药品规格,Price AS 价格 FROM tb_Medicine ";
            sqlCommand1.CommandText =
                $@"SELECT NO AS 编号, MedicineName AS 药品名称,MedicineClassify AS 药品类型
         ,Specification AS 药品规格,Price AS 价格 FROM tb_MedicalOrder ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter();
            sqlDataAdapter1.SelectCommand = sqlCommand1;
            sqlDataAdapter.SelectCommand = sqlCommand;
            this.MedicineOrderTable =new DataTable();
            this.MedicineTable=new DataTable();
            this.MedicineTable.TableName = "Medicine";
            DataColumn rowIdColumn = new DataColumn();                                                     
            rowIdColumn.ColumnName = "RowID";                                                               
            rowIdColumn.DataType = typeof(int);                                                             
            rowIdColumn.AutoIncrement = true;                                                               
            rowIdColumn.AutoIncrementSeed = 1;                                                             
            rowIdColumn.AutoIncrementStep = 1;
            this.MedicineTable .Columns.Add(rowIdColumn);
            sqlConnection .Open ();
            sqlDataAdapter1.Fill(this.MedicineOrderTable);
            sqlDataAdapter.Fill(this.MedicineTable);
            sqlConnection.Close ();
            this.maxpagesize =
                (int)Math.Ceiling((double)this.MedicineTable .Rows.Count / (double)this.pagesize );
            this.MedicineView  = new DataView();                                                         
            this.MedicineView.Table = this.MedicineTable ;                                              
            this.MedicineView.Sort = "RowID ASC";                                                        
            this.RefreshRowFilter();
            this.dataGridView1.Columns.Clear ();
            this.dataGridView1.DataSource = this.MedicineView ;
            this.dataGridView1 .Columns["PINYIN"].Visible = false;
            this.dataGridView1 .Columns["RowID"].Visible=false;
            this.dataGridView1 .Columns[this.dataGridView1 .ColumnCount - 1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridView2 .Columns.Clear ();
            this .dataGridView2 .DataSource = this.MedicineOrderTable;
            this.dataGridView2 .Columns[this .dataGridView2 .ColumnCount -1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            this.lblPrice1.Text =
                $"此订单共花费{this.MedicineOrderTable.Compute("SUM(价格)", "")}元";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.RowCount == 0)
                return;
            DataRowView currentMedicalWiew=this.dataGridView1.CurrentRow .DataBoundItem  as DataRowView;
            DataRow MedicalRow = currentMedicalWiew.Row
                , SelectMedicineRow = this.MedicineOrderTable.NewRow();
            SelectMedicineRow["编号"] = MedicalRow["编号"];
            SelectMedicineRow["药品名称"] = MedicalRow["药品名称"];
            SelectMedicineRow["药品类型"] = MedicalRow["药品类型"];
            SelectMedicineRow["药品规格"] = MedicalRow["药品规格"];
            SelectMedicineRow["价格"] = MedicalRow["价格"];
            this.MedicineOrderTable .Rows .Add (SelectMedicineRow);
            MedicalRow.Delete();
            this.lblPrice1.Text =
                $"此订单共花费{this.MedicineOrderTable.Compute("SUM(价格)", "")}元";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.dataGridView2 .RowCount == 0)                                                      
                return;                                                                                   
            DataRowView selectedMedicineRowView =
                this.dataGridView2 .CurrentRow.DataBoundItem as DataRowView;                           
            DataRow selectedMedicineRow = selectedMedicineRowView.Row;                                          
            if (selectedMedicineRow.RowState != DataRowState.Added)                                           
                return;                                                                                    
            string No = selectedMedicineRow["编号"].ToString();											
            DataRow deletedCourseRow =																		
                this.MedicineTable .Select($"编号='{No}'", "", DataViewRowState.Deleted)[0];			   
            deletedCourseRow.RejectChanges();																
            this.MedicineOrderTable .Rows.Remove(selectedMedicineRow);										
            this.lblPrice1 .Text =																	
                $"此订单共花费{this.MedicineOrderTable .Compute("SUM(价格)", "")}元";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand .Connection = sqlConnection;
            sqlCommand.CommandText =
                $@"INSERT tb_MedicalOrder (NO ,MedicineName ,MedicineClassify ,Specification ,Price )VALUES
                     (@NO,@MedicineName,@MedicineClassify,@Specification,@Price )";
            sqlCommand.Parameters.Add("@NO", SqlDbType.VarChar ,0, "编号");
            sqlCommand.Parameters.Add("@MedicineName", SqlDbType.VarChar, 0, "药品名称");
            sqlCommand.Parameters.Add("@MedicineClassify", SqlDbType.VarChar, 0, "药品类型");
            sqlCommand.Parameters.Add("@Specification", SqlDbType.VarChar, 0, "药品规格");
            sqlCommand.Parameters.Add("@Price", SqlDbType.VarChar, 0, "价格");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.InsertCommand  = sqlCommand;
            sqlConnection .Open();
            int row = sqlDataAdapter.Update(this.MedicineOrderTable);
            sqlConnection .Close();
            MessageBox.Show($"已确定下单{row}种药品");
            this.lblPrice1.Text =
                $"此订单共花费{this.MedicineOrderTable.Compute("SUM(价格)", "")}元";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataRow[] searchResultRows =
                this.MedicineTable.Select($"PINYIN LIKE '%{this.textBox1 .Text.Trim()}%'");
            DataTable searchResultTable = this.MedicineTable.Clone();
            foreach (DataRow row in searchResultRows)
            {
                searchResultTable.ImportRow(row);
            }
            this.dataGridView1.DataSource = searchResultTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.currentpage > 1)
            {
                this.currentpage--;
            }
            this.RefreshRowFilter ();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.currentpage < this.maxpagesize )
            {
                this.currentpage++;
            }
            this.RefreshRowFilter();
        }
    }
}
