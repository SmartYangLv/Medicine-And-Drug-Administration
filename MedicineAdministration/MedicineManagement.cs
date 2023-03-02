using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.AccessControl;

namespace MedicineAdministration
{
    public partial class MedicineManagement : Form
    {
        public string _No;
        public MedicineManagement()
        {
            InitializeComponent();
            this.StartPosition= FormStartPosition.CenterScreen;
        }
        public MedicineManagement(string no):this ()
        {
            this._No = no;
        }
        private void MedicineManagement_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection=sqlConnection;
            //sqlCommand.CommandText = $@"SELECT * FROM tb_Medicine";
            sqlCommand.CommandText = $@"SELECT No AS 编号,MedicineName AS 名称,MedicineClassify AS 分类
             ,Manufacturer AS 生产厂家,Specification 规格,InventoryQuantity AS 数量,Price AS 价格
             , iif (DATEDIFF(DAY,ExpirationTime,GETDATE())>-30,'忽略预警','1') AS 操作 FROM tb_Medicine  
              WHERE DATEDIFF (DAY ,ExpirationTime ,GETDATE ())>-30";
            SqlDataAdapter sqlDataAdapter= new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable MedicineTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill (MedicineTable);
            sqlConnection.Close();
            this.Dgv_Medicine .Columns.Clear();
            this.Dgv_Medicine.DataSource = MedicineTable;
            //DataGridViewComboBoxColumn classColumn = new DataGridViewComboBoxColumn();
            //this.Dgv_Medicine.Columns.Add(classColumn);
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonalInformation personalInformation = new PersonalInformation(this._No);
            personalInformation.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection=sqlConnection;
            sqlCommand.CommandText = $@"SELECT No AS 编号,MedicineName AS 名称,MedicineClassify AS 分类
             ,Manufacturer AS 生产厂家,Specification 规格,InventoryQuantity AS 数量,Price AS 价格
             , iif (DATEDIFF(DAY,ExpirationTime,GETDATE())>-30,'忽略预警','1') AS 操作 FROM tb_Medicine  
              WHERE MedicineName=@MedicineName;";
            sqlCommand.Parameters.AddWithValue("@MedicineName", this.Txb_MedNane.Text.Trim());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable MedicineTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill(MedicineTable);
            sqlConnection.Close();
            this.Dgv_Medicine.Columns.Clear();
            this.Dgv_Medicine.DataSource = MedicineTable;
        }
    }
}  
