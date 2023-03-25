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
    public partial class MedicalReport : Form
    {
        public string _No;
        private DataTable MedicalTable;
        private DataTable MedicalReportTable;
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
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            SqlCommand sqlCommand1 = new SqlCommand();
            sqlCommand1.Connection = sqlConnection;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                $@"SELECT No AS 编号,MedicineName AS 药品名称,MedicineClassify AS 药品分类
       ,InventoryQuantity AS 药品数量,ExpirationTime AS 过期时间,Price AS 价格 FROM tb_Medicine";
            sqlCommand1.CommandText =
                $@"SELECT No AS 编号,MedicineName AS 药品名称,MedicineClassify AS 药品分类
       ,InventoryQuantity AS 药品数量,ExpirationTime AS 过期时间,Price AS 价格 FROM tb_MedicalReport";
            SqlDataAdapter sqlDataAdapter =new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter();
            sqlDataAdapter1 .SelectCommand = sqlCommand1;
            this.MedicalTable =new DataTable();
            this.MedicalReportTable =new DataTable();
            sqlConnection .Open ();
            sqlDataAdapter1.Fill(this.MedicalReportTable);
            sqlDataAdapter .Fill (this.MedicalTable);
            sqlConnection.Close ();
            this.dgv_Medical.Columns.Clear ();
            this .dgv_Medical .DataSource = this.MedicalTable;
            this.dgv_MedicalReport .Columns.Clear ();
            this.dgv_MedicalReport.DataSource = this.MedicalReportTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dgv_Medical.RowCount == 0)
                return;
            DataRowView MedicalRowView=
                this.dgv_Medical .CurrentRow .DataBoundItem as DataRowView;
            DataRow MedicalRow = MedicalRowView.Row
                ,MedicalReportRow=this.MedicalReportTable .NewRow () ;
            MedicalReportRow["编号"] = MedicalRow["编号"];
            MedicalReportRow["药品名称"] = MedicalRow["药品名称"];
            MedicalReportRow["药品分类"] = MedicalRow["药品分类"];
            MedicalReportRow["药品数量"] = MedicalRow["药品数量"];
            MedicalReportRow["过期时间"] = MedicalRow["过期时间"];
            MedicalReportRow["价格"] = MedicalRow["价格"];
            this.MedicalReportTable .Rows.Add  (MedicalReportRow);
            MedicalRow.Delete();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.dgv_MedicalReport.RowCount==0)
                return;
            DataRowView MedicalReportRowView=
                this.dgv_MedicalReport.CurrentRow .DataBoundItem as DataRowView;
            DataRow MedicalReportRow = MedicalReportRowView.Row;
            if (MedicalReportRow.RowState != DataRowState.Added)
                return;
            string No = MedicalReportRow["编号"].ToString ();
            DataRow DeletMedicalRow =
                this.MedicalTable.Select($"编号='{No}'", "", DataViewRowState.Deleted)[0];
            DeletMedicalRow.RejectChanges();
            this.MedicalReportTable.Rows.Remove(MedicalReportRow);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
               ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = sqlConnection.CreateCommand ();
            sqlCommand.CommandText =
                $@"INSERT tb_MedicalReport (NO ,MedicineName,MedicineClassify ,InventoryQuantity ,ExpirationTime ,Price )
                   VALUES(@NO,@MedicineName,@MedicineClassify,@InventoryQuantity,@ExpirationTime,@Price)";
            sqlCommand.Parameters.AddWithValue("@NO", "编号");
            sqlCommand.Parameters.Add("@MedicineName", SqlDbType.VarChar,0,"药品名称");
            sqlCommand.Parameters.Add("@MedicineClassify", SqlDbType.VarChar, 0, "药品分类");
            sqlCommand.Parameters.Add("@InventoryQuantity", SqlDbType.Int , 50, "药品数量");
            sqlCommand.Parameters.Add("@ExpirationTime", SqlDbType.Date , 50, "过期时间");
            sqlCommand.Parameters.Add("@Price", SqlDbType.VarChar, 0, "价格");
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter .InsertCommand = sqlCommand;
            sqlConnection .Open ();
            int row = sqlDataAdapter.Update(this.MedicalReportTable);
            sqlConnection .Close ();
            MessageBox.Show($"报损{row}行!");
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
    }
}
