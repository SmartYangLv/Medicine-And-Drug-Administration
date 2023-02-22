using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace MedicineAdministration
{
    public partial class PersonalInformation : Form
    {
        public string No;
        public PersonalInformation()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen ;
            this .LoadInformation ();
        }
        public PersonalInformation (string no):this () 
        {
            this.No = no;
        }
        private  void LoadInformation()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = $@"SELECT * FROM tb_User WHERE NO='{this .No }';";
            //sqlCommand.Parameters.AddWithValue("@No", this.No);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                this.Txb_Name.Text = sqlDataReader["Name"].ToString();
                this.Txb_Gender.Text = sqlDataReader["Gender"].ToString();
                this.txb_Birthday.Value = (DateTime)sqlDataReader["Birthday"];
                this.Txb_Number.Text = sqlDataReader["Number"].ToString();
                this.Txb_Department.Text = sqlDataReader["Department"].ToString();
                this.Txb_Post.Text = sqlDataReader["Post"].ToString();
                this.Txb_WorkTime.Value = (DateTime)sqlDataReader["WorkTime"];
                this.Txb_Salary.Text = sqlDataReader["Salary"].ToString();
            }
            sqlConnection.Close();
        }
        private void Personal_Information_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = $@"SELECT * FROM tb_User WHERE NO=@No;";
            sqlCommand.Parameters.AddWithValue("@No", this.No);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                this.Txb_Name.Text = sqlDataReader["Name"].ToString();
                this.Txb_Gender.Text = sqlDataReader["Gender"].ToString();
                this.txb_Birthday.Value = (DateTime)sqlDataReader["Birthday"];
                this.Txb_Number.Text = sqlDataReader["Number"].ToString();
                this.Txb_Department.Text = sqlDataReader["Department"].ToString();
                this.Txb_Post.Text = sqlDataReader["Post"].ToString();
                this.Txb_WorkTime.Value = (DateTime)sqlDataReader["WorkTime"];
                this.Txb_Salary.Text = sqlDataReader["Salary"].ToString();
            }
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection() ;
            sqlConnection .ConnectionString =ConfigurationManager .ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand .Connection = sqlConnection;
            sqlCommand.CommandText = $@"UPDATE tb_User 
                     SET Name=@Name , Gender=@Gender ,Birthday=@Birthday ,Number=@Number,Department=@Department
                        ,Post=@Post ,WorkTime=@WorkTime ,Salary=@Salary WHERE NO=@No";
            sqlCommand.Parameters.AddWithValue("@No", this.No);
            sqlCommand.Parameters.AddWithValue("@Name", this.Txb_Name.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Gender", this.Txb_Gender.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Birthday", this.txb_Birthday.Value);
            sqlCommand.Parameters.AddWithValue("@Number", this.Txb_Number.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Department", this.Txb_Department.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Post", this.Txb_Post.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@WorkTime", this.Txb_WorkTime.Value);
            sqlCommand.Parameters.AddWithValue("@Salary", this.Txb_Salary.Text.Trim());
            int row = 0;
            try
            {
                sqlConnection.Open();
                row = sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("更新失败，请联系管理员");
            }
            finally { sqlConnection.Close(); }
            if(row!=0)
            {
                MessageBox.Show($"更新{row}行");
            }
            this.LoadInformation ();
        }
    }
}
