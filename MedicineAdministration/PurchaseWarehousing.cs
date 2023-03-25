using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicineAdministration
{
    public partial class PurchaseWarehousing : Form
    {
        private DataTable dataTable;
        private DataView  MedicalView;
        private int pagesize;
        private int currentpageNo;
        private int Maxpage;
        private DataView CourseViewByName;
        public string _No;
        public PurchaseWarehousing()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public PurchaseWarehousing (string no):this()
        {
            _No = no;
        }
        private void RefreshRowFilter()
            => this.MedicalView.RowFilter =
            $"RowID>{(this.currentpageNo - 1) * this.pagesize}" +
            $"AND RowID<={(this.currentpageNo) * this.pagesize}";

        private void PurchaseWarehousing_Load(object sender, EventArgs e)
        {
            this.pagesize = 10;
            this.currentpageNo = 1;
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection .ConnectionString=
                ConfigurationManager.ConnectionStrings ["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnection;
            SqlCommand sqlCommand2= new SqlCommand();
            sqlCommand2.Connection = sqlConnection;
            sqlCommand2.CommandText = $@"SELECT MedicineName FROM tb_Medicine";
            sqlCommand1.CommandText =
                $@"SELECT * FROM tb_Unit";
            sqlCommand.CommandText =
                 $@"SELECT No AS 编号,MedicineName AS 名称,MedicineClassify AS 分类,Manufacturer  AS 生产厂商 ,InventoryQuantity AS 现存数量,UnitNo 
              FROM tb_Medicine
               WHERE No Not IN (SELECT No FROM tb_MedicineNo)";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            this.dataTable = new DataTable();
            this.dataTable.TableName = "Medical";
            DataColumn column = new DataColumn();
            column.ColumnName = "RowID";
            column.DataType = typeof(int); 
            column .AutoIncrement = true;
            column .AutoIncrementSeed = 1;
            column .AutoIncrementStep = 1;
            this.dataTable.Columns.Add(column);
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter();
            sqlDataAdapter1 .SelectCommand = sqlCommand1;
            sqlDataAdapter1.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter();
            sqlDataAdapter2 .SelectCommand = sqlCommand2;
            sqlDataAdapter2.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            DataTable NameTable= new DataTable();
            DataTable UnitTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter2.Fill(NameTable);
            this.cbx_Name.DataSource = NameTable;
            this.cbx_Name.DisplayMember = "MedicineName";
            this.cbx_Name.ValueMember = "";
            sqlDataAdapter1.Fill(UnitTable);
            sqlDataAdapter .Fill (dataTable);
            sqlConnection.Close ();
            this.Maxpage =
                (int)Math.Ceiling((double)this.dataTable.Rows .Count /(double )this.pagesize);
            this.MedicalView = new DataView();
            this.MedicalView.Table = this.dataTable;
            this.MedicalView.Sort = "RowID ASC";
            this.RefreshRowFilter ();
            this.CourseViewByName = new DataView();
            this.CourseViewByName.Table = this.dataTable;
            this.CourseViewByName.Sort = "名称 ASC";
            this.dgv_PurchaseTable .Columns.Clear();
            this.dgv_PurchaseTable.DataSource =this.MedicalView ;
            this.dgv_PurchaseTable.Columns["UnitNo"].Visible = false;
            this.dgv_PurchaseTable.Columns["RowID"].Visible = false;
            this.dgv_PurchaseTable .Columns[this.dgv_PurchaseTable .Columns.Count - 1].AutoSizeMode =                     
                DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewComboBoxColumn UnitColumn = new DataGridViewComboBoxColumn();
            this.dgv_PurchaseTable .Columns .Add (UnitColumn);
            UnitColumn.Name = "unit";
            UnitColumn.HeaderText = "单位";
            UnitColumn .DataSource = UnitTable ;
            UnitColumn.DisplayMember = "unit";
            UnitColumn.ValueMember = "No";
            UnitColumn.DataPropertyName = "UnitNo";
            UnitColumn.DisplayIndex =6;
            UnitColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgv_PurchaseTable .Columns[this.dgv_PurchaseTable.Columns.Count - 2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
            DataGridViewTextBoxColumn AddColumn=new DataGridViewTextBoxColumn();
            this.dgv_PurchaseTable .Columns.Add(AddColumn);
            AddColumn .Name ="Add";
            AddColumn .HeaderText ="药品采购数";
            AddColumn .DisplayIndex =5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRowView[] searchResultRowViews =
                this.CourseViewByName.FindRows(this.cbx_Name .Text.Trim());                            
            DataTable searchResultTable = this.dataTable.Clone();                                         
            foreach (DataRowView dataRowView in searchResultRowViews)                                       
            {
                searchResultTable.ImportRow(dataRowView.Row);                                               
            }
            this.dgv_PurchaseTable .DataSource = searchResultTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            int unit=int.Parse (this.dgv_PurchaseTable .CurrentRow.Cells["Add"].Value.ToString());
            if(unit!=' ')
            {
                sqlCommand.CommandText =
                    $@"INSERT INTO tb_MedicineNo(No,Num)VALUES(@No,@Num)";
                sqlCommand .Parameters .AddWithValue ("@No",this.dgv_PurchaseTable .CurrentRow.Cells ["编号"].Value .ToString ());
                sqlCommand.Parameters.AddWithValue("@Num", unit);
                sqlConnection.Open();
                int row=sqlCommand.ExecuteNonQuery ();
                sqlConnection .Close();
                if(row > 0)
                {
                    MessageBox.Show("已预采购");
                }
               else
                {
                    MessageBox.Show("采购失败！请联系管理员处理");
                }
            }
        }

        private void 入库审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WarehousingAudit warehousingAudit = new WarehousingAudit(this._No );
            warehousingAudit.Show();
            this.Hide();
        }

        private void 库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicineManagement medicineManagement = new MedicineManagement(this._No );
            medicineManagement.Show();
            this.Hide();
        }

        private void 药物报损ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicalReport medicalReport = new MedicalReport(this._No );
            medicalReport.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(this.currentpageNo >1)
                this.currentpageNo--;
            this.RefreshRowFilter();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(this.currentpageNo <this.Maxpage )
                this.currentpageNo++;
            this.RefreshRowFilter();
        }
    }
}
