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
    public partial class WarehousingAudit : Form
    {
        public string _No;
        public WarehousingAudit()
        {
            InitializeComponent();
            this.StartPosition= FormStartPosition.CenterScreen;
            this.loaddate();
        }
        public WarehousingAudit (string no):this() 
        {
            _No = no;
        }
        public void  loaddate()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = $@"SELECT S.No AS 编号,MedicineName AS 名称,MedicineClassify AS 分类,Manufacturer  AS 生产厂商 ,InventoryQuantity AS 现存数量,ss.Num as 采购数 
               FROM tb_Medicine AS S JOIN tb_MedicineNo AS SS ON S.No =SS.No ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable dataTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            this.dgv_Aduit.Columns.Clear();
            this.dgv_Aduit.DataSource = dataTable;
        }
        private void WarehousingAudit_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection =new SqlConnection ();
            sqlConnection.ConnectionString =
                ConfigurationManager .ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = $@"SELECT S.No AS 编号,MedicineName AS 名称,MedicineClassify AS 分类,Manufacturer  AS 生产厂商 ,InventoryQuantity AS 现存数量,ss.Num as 采购数 
               FROM tb_Medicine AS S JOIN tb_MedicineNo AS SS ON S.No =SS.No ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable dataTable= new DataTable();
            sqlConnection.Open();
            sqlDataAdapter .Fill(dataTable);
            sqlConnection .Close();
            this.dgv_Aduit .Columns.Clear();
            this.dgv_Aduit.DataSource = dataTable;
        }

        private void 采购入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseWarehousing purchaseWarehousing = new PurchaseWarehousing(this._No);
            purchaseWarehousing.Show();
            this.Hide();
        }

        private void 药物预警ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicineManagement medicineManagement = new MedicineManagement(this._No);
            medicineManagement.Show();
            this.Hide ();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection =new SqlConnection ();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand .Connection=sqlConnection;
            int unit = int.Parse(this.dgv_Aduit.CurrentRow.Cells["采购数"].Value.ToString());
            if (unit != 0)
            {
                sqlCommand.CommandText =
                    $@"DELETE tb_MedicineNo WHERE No=@No";
                sqlCommand.Parameters.AddWithValue ("@No",this.dgv_Aduit .CurrentRow .Cells["编号"].Value .ToString ());
                sqlConnection.Open ();
                int row =sqlCommand .ExecuteNonQuery ();
                sqlCommand .Clone();
                if(row != 0)
                {
                    MessageBox.Show("已取消");
                }
                else
                {
                    MessageBox.Show("取消失败！，请联系管理员");
                }
            }
            this.loaddate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand .Connection =sqlConnection;
            sqlCommand.CommandText =
                $@"UPDATE tb_Medicine
                     SET InventoryQuantity+=@InventoryQuantity
                     WHERE No='{this.dgv_Aduit .CurrentRow .Cells["编号"].Value .ToString ()}'";
            int num=int.Parse (this.dgv_Aduit .CurrentRow.Cells["采购数"].Value .ToString ());
            sqlCommand.Parameters.AddWithValue("@InventoryQuantity", num);
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnection;
            sqlCommand1.CommandText =
                $@"UPDATE tb_MedicineNo
                   SET Num='{0}'
                   WHERE No='{this.dgv_Aduit.CurrentRow.Cells["编号"].Value.ToString()}'";
            sqlConnection.Open();
            int row1=sqlCommand1 .ExecuteNonQuery();
            int row=sqlCommand.ExecuteNonQuery ();
            sqlConnection.Close();
            if(row> 0)
            {
                MessageBox.Show("采购成功");
            }
            else
            {
                MessageBox.Show("采购失败！请联系管理员处理");
            }
            this.loaddate();
        }

        private void 药物报损ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicalReport medicalReport = new MedicalReport(this._No );
            medicalReport.Show();
            this.Hide();
        }
    }
}
