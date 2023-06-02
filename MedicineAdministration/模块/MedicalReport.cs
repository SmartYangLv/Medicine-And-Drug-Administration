using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicineAdministration
{
    public partial class MedicalReport : Form
    {
        public string _No;
        private DataTable MedicalTable;
        public MedicalReport()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public MedicalReport(string No):this() 
        { 
            this._No = No;
        }
        private void MedicalReport_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["sql"].ToString ();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                $@"SELECT NO AS 编号,MedicineName AS 名称, Manufacturer AS 厂商, Specification AS 药品规格,ExpirationTime AS 过期时间,Price AS 价格  FROM tb_Medicine
               WHERE IsActioned !<0";
            SqlDataAdapter sqlDataAdapter =new SqlDataAdapter();
            this.MedicalTable =new DataTable();
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlConnection .Open ();
            sqlDataAdapter.Fill(this.MedicalTable);
            sqlConnection.Close ();
            this.dgv_Medical .DataSource = this.MedicalTable;
            DataGridViewCheckBoxColumn CheckColumn= new DataGridViewCheckBoxColumn();
            this.dgv_Medical.Columns.Add( CheckColumn );
            CheckColumn.Name = "CheckColumn";
            CheckColumn.HeaderText = "操作";
            CheckColumn.DisplayIndex = 0;
                
        }
        private void 药品预警ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicineManagement  medicineManagement = new MedicineManagement(this._No);
            medicineManagement.Show();
            this.Hide();
        }

        private void 采购入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseWarehousing purchaseWarehousing = new PurchaseWarehousing(this._No);
            purchaseWarehousing.Show();
            this.Hide();
        }

        private void 入库审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WarehousingAudit warehousingAudit =new WarehousingAudit(this._No);
            warehousingAudit.Show();
            this.Hide();
        }

        private void 药物调价ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string m = "";
            int count = Convert.ToInt16(this.dgv_Medical.Rows.Count.ToString());
            for(int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell check=(DataGridViewCheckBoxCell )dgv_Medical.Rows[i].Cells["CheckColumn"];
                Boolean flag = Convert.ToBoolean(check.Value);
                DataGridViewRow row1 =dgv_Medical .Rows[i];
                if(flag ==true )
                {
                    m = Convert.ToString (row1.Cells["编号"].Value);
                    SqlConnection sqlConnection = new SqlConnection();
                    sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["sql"].ToString();
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandText =
                        $@"UPDATE tb_Medicine
                   SET IsActioned-=1
                   WHERE No=@No";
                    sqlCommand.Parameters.AddWithValue("@No",m );
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.UpdateCommand = sqlCommand;
                    sqlConnection.Open();
                    int row = sqlCommand .ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("报损成功");
                }
                continue;
            }
            
        }

        private void 供应商维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplierMaintenance supplierMaintenance = new SupplierMaintenance();
            supplierMaintenance .Show ();
            this.Hide();
        }
    }
}
