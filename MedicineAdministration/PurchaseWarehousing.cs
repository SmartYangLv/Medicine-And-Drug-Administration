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
    public partial class PurchaseWarehousing : Form
    {
        private DataTable dataTable;
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

        private void PurchaseWarehousing_Load(object sender, EventArgs e)
        {
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
                 $@"SELECT No AS 编号,MedicineName AS 名称,MedicineClassify AS 分类,Manufacturer  AS 生产厂商 ,InventoryQuantity AS 现存数量,UnitNo FROM tb_Medicine";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            this.dataTable = new DataTable();
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
            this.CourseViewByName = new DataView();
            this.CourseViewByName.Table = this.dataTable;
            this.CourseViewByName.Sort = "名称 ASC";
            this.dgv_PurchaseTable .Columns.Clear();
            this.dgv_PurchaseTable.DataSource = dataTable;
            this.dgv_PurchaseTable.Columns["UnitNo"].Visible = false;
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
                this.CourseViewByName.FindRows(this.cbx_Name .Text.Trim());                            //借助本窗体的按名称排序的课程数据视图的方法FindRows，根据排序列（即课程名称）快速查找相应课程；由于该列并非主键，可能返回多行查询结果，故返回数据行视图数组；数据行视图数组不能直接作为数据源，需转为列表后方可作为数据源；
            DataTable searchResultTable = this.dataTable.Clone();                                         //借助本窗体的课程数据表的方法Clone，创建相同架构的空表，用于保存搜索结果所在数据行；
            foreach (DataRowView dataRowView in searchResultRowViews)                                       //遍历搜索结果所在数据行视图数组；
            {
                searchResultTable.ImportRow(dataRowView.Row);                                               //通过每条数据行视图的属性Row获取相应的数据行，并导入数据表；
            }
            this.dgv_PurchaseTable .DataSource = searchResultTable;
        }
    }
}
