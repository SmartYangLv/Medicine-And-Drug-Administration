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
    public partial class MedicinePriceAdjustment : Form
    {
        public MedicinePriceAdjustment()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MedicinePriceAdjustment_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection =new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
             "SELECT * FROM tb_MedicineClassify;"+
            "SELECT * FROM tb_MedicineClassify1;"+
            "SELECT * FROM tb_MedicineClassify2;"; 
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlConnection .Open ();
            sqlDataAdapter.Fill (dataSet);
            sqlConnection .Close ();
            DataTable Classify = dataSet.Tables[0];
            DataTable Classify1 = dataSet.Tables[1];
            DataTable Classify2 = dataSet.Tables[2];
            DataRelation[] dataRelations =
            {
                new DataRelation
                ("Classify_Classify1",
                Classify .Columns ["No"],
                Classify1 .Columns ["MedClassify1"]),
                new DataRelation
                ("Classify1_Classify2",
                Classify1.Columns ["No"],
                Classify2 .Columns ["MedClassify2"])
            };
            dataSet .Relations .AddRange (dataRelations);
            this.trv_Medicine .Nodes .Clear ();
            foreach (DataRow ClassifyRow in Classify.Rows)
            {
                TreeNode ClassifyNode = new TreeNode ();
                ClassifyNode .Text = ClassifyRow["Classify"].ToString ();
                this.trv_Medicine .Nodes .Add (ClassifyNode);
                foreach (DataRow Classify1Row in ClassifyRow.GetChildRows("Classify_Classify1"))
                {
                    TreeNode Classify1Node = new TreeNode ();
                    Classify1Node .Text =Classify1Row["Classify1"].ToString();
                    ClassifyNode.Nodes.Add(Classify1Node);
                    foreach (DataRow Clssify2Row in Classify1Row.GetChildRows("Classify1_Classify2"))
                    {
                        TreeNode Classify2Node= new TreeNode ();
                        Classify2Node.Text = Clssify2Row["Classify2"].ToString() ;
                        Classify2Node .Tag = Clssify2Row["No"] ;
                        Classify1Node .Nodes.Add(Classify2Node);
                    }
                }
            }
                
        }

        private void trv_Medicine_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.trv_Medicine.SelectedNode.Level != 2)
                return;
            int MedicineClassify=(int )this.trv_Medicine .SelectedNode.Tag;
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = sqlConnection.CreateCommand ();
            sqlCommand.CommandText =
                $@"SELECT NO AS 编号, MedicineName AS 药品名称 FROM tb_Medicine 
                   WHERE MedicineClassify=@MedicineClassify;";
            sqlCommand.Parameters.AddWithValue("@MedicineClassify", MedicineClassify);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter .SelectCommand = sqlCommand;
            DataTable dataTable = new DataTable();
            sqlConnection .Open ();
            sqlDataAdapter .Fill (dataTable);
            sqlConnection .Close ();
            this.dgv_Medicine .DataSource = dataTable;
            this.dgv_Medicine .Columns[this.dgv_Medicine .Columns .Count - 1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgv_Medicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection sqlConnection=new SqlConnection ();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = sqlConnection.CreateCommand ();
            sqlCommand.CommandText =
                $@"SELECT NO ,MedicineName ,Manufacturer ,Specification ,Action ,Price  FROM tb_Medicine  
                   WHERE NO=@No";
            sqlCommand.Parameters.AddWithValue("@No", this.dgv_Medicine.CurrentRow.Cells["编号"].Value.ToString());
            sqlConnection .Open();
            int row=sqlCommand.ExecuteNonQuery();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                txt_No.Text = reader["NO"].ToString();
                txt_Name.Text = reader["MedicineName"].ToString();
                txt_Manufacturer.Text = reader["Manufacturer"].ToString();
                txt_Specification.Text = reader["Specification"].ToString();
                txt_User.Text = reader["Action"].ToString();
                txt_Price.Text = reader["Price"].ToString();
            }
            sqlConnection .Close();
            txt_No.ReadOnly = true;
            txt_Name.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MedicineManagement medicineManagement = new MedicineManagement();
            medicineManagement.Show();
            this.Hide ();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection=new SqlConnection ();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = sqlConnection.CreateCommand ();
            sqlCommand.CommandText =
                $@" UPDATE tb_Medicine 
                SET Manufacturer =@Manufacturer,Specification =@Specification,Action =@Action,Price =@Price
               WHERE No=@No;";
            sqlCommand.Parameters.AddWithValue("@No", this.txt_No.Text);
            sqlCommand.Parameters.AddWithValue("@Manufacturer", this.txt_Manufacturer.Text);
            sqlCommand.Parameters.AddWithValue("@Specification", this.txt_Specification.Text);
            sqlCommand.Parameters.AddWithValue("@Action", this.txt_User.Text);
            sqlCommand.Parameters.AddWithValue("@Price", int.Parse(this.txt_Price.Text));
            sqlConnection .Open();
            int row=sqlCommand .ExecuteNonQuery();
            sqlConnection .Close();
            MessageBox.Show($"成功更新{row}行");
        }
    }
}
