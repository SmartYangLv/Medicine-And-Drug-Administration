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
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                "Server=(local);Database=MedicineDrug;Integrated Security=sspi";
            SqlCommand sqlCommand =new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = $@"SELECT COUNT(1) FROM tb_User 
             WHERE NO =@NO AND Password =HASHBYTES('MD5',@Password);";
            sqlCommand.Parameters.AddWithValue("@NO", this.txb_No.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Password", this.txb_Password.Text.Trim());
            sqlCommand.Parameters["@Password"].SqlDbType = System.Data.SqlDbType.VarChar;
            sqlConnection.Open();
            int rowCount=(int)sqlCommand.ExecuteScalar();
            sqlConnection.Close ();
            if(rowCount == 1)
            {
                MessageBox.Show("登录成功");        
            }
            else
            {
                MessageBox.Show("用户名或者密码错误，请重新输入");
                this.txb_Password.Focus();
                this.txb_Password.SelectAll();
            }
        }

        private void SingUp_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection =new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand =new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand .CommandText =$@"INSERT INTO tb_User (NO,Password) VALUES(@NO,HASHBYTES('MD5',@Password))";
            sqlCommand.Parameters.AddWithValue("@NO", this.txb_No.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Password", this.txb_Password.Text.Trim());
            sqlCommand.Parameters["@Password"].SqlDbType = SqlDbType.VarChar;
            sqlConnection .Open ();
            int rowCount = sqlCommand.ExecuteNonQuery();
            sqlConnection .Close ();
            if(rowCount == 1)
            {
                MessageBox.Show("注册成功");
            }
            else
            {
                MessageBox.Show("注册失败");
            }
        }
    }
}
