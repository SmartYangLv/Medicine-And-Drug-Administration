using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace MedicineAdministration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txb_No.Text.Trim() == "")
            {
                this.Lab_No.Text = "用户名不能为空!";
                this.txb_No.Focus();
            }
            else
            {
                this.Lab_No.Text = "";
            }
            if (this.txb_Password.Text.Trim() == "")
            {
                this.LabPaw.Text = "密码不能为空!";
                this.txb_Password.Focus();
            }
            else
            {
                this.LabPaw.Text = "";
            }
            if (this.txb_No.Text.Trim() != "" && this.txb_Password.Text.Trim() != "")
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString =
                    "Server=(local);Database=MedicineDrug;Integrated Security=sspi";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $@"SELECT COUNT(1) FROM tb_User 
             WHERE NO =@NO AND Password =HASHBYTES('MD5',@Password);";
                sqlCommand.Parameters.AddWithValue("@NO", this.txb_No.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@Password", this.txb_Password.Text.Trim());
                sqlCommand.Parameters["@Password"].SqlDbType = System.Data.SqlDbType.VarChar;
                sqlConnection.Open();
                int rowCount = (int)sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                if (rowCount == 1)
                {
                    //MessageBox.Show("登录成功");
                    MedicineManagement medicineManagement = new MedicineManagement(this.txb_No.Text.Trim());
                    medicineManagement.Show();
                    this.Hide  ();
                }
                else
                {
                    MessageBox.Show("用户名或者密码错误，请重新输入");
                    this.txb_Password.Focus();
                    this.txb_Password.SelectAll();
                }
            }
        }
        private void SingUp_Click(object sender, EventArgs e)
        {
            if (this.txb_No.Text.Trim() == "")
            {
                this.Lab_No.Text = "用户名不能为空!";
                this.txb_No.Focus();
            }
            else
            {
                this.Lab_No.Text = "";
            }
            if (this.txb_Password.Text.Trim() == "")
            {
                this.LabPaw.Text = "密码不能为空!";
                this.txb_Password.Focus();
            }
            else
            {
                this.LabPaw.Text = "";
            }
            if (this.txb_No.Text.Trim() != "" && this.txb_Password.Text.Trim() != "")
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = $@"INSERT INTO tb_User (NO,Password) VALUES(@NO,HASHBYTES('MD5',@Password))";
                sqlCommand.Parameters.AddWithValue("@NO", this.txb_No.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@Password", this.txb_Password.Text.Trim());
                sqlCommand.Parameters["@Password"].SqlDbType = SqlDbType.VarChar;
                int rowCount = 0;
                try
                {
                    sqlConnection.Open();
                    rowCount = sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                { 
                    if(sqlEx.Number  == 2627)
                    {
                        this.Lab_No.Text = "该用户名已存在！";
                        this.Lab_No .Focus ();
                    }
                    else
                    {
                        MessageBox.Show("注册失败，请联系管理员！");
                    }
                }
                finally 
                { 
                    sqlConnection.Close();
                }
                if (rowCount == 1)
                {
                    MessageBox.Show("注册成功");
                    PersonalInformation personalInformation = new PersonalInformation(this.txb_No.Text.Trim());
                    personalInformation.Show();
                }
            }
        }
    }
}
