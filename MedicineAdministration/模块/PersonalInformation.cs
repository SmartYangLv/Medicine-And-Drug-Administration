using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Environment;

namespace MedicineAdministration
{
    public partial class PersonalInformation : Form
    {
        public string No;
        public PersonalInformation()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        public PersonalInformation(string no) : this()
        {
            this.No = no;
        }
        private void Personal_Information_Load(object sender, EventArgs e)
        {

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            SqlCommand sqlCommand1 = new SqlCommand();
            SqlCommand sqlCommand2 = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand1.Connection = sqlConnection;
            sqlCommand2.Connection = sqlConnection;
            sqlCommand1.CommandText = $@"SELECT * FROM tb_Post";
            sqlCommand2.CommandText = $@"SELECT * FROM tb_Department";
            sqlCommand.CommandText = $@"SELECT * FROM tb_User WHERE NO=@No;";
            sqlCommand.Parameters.AddWithValue("@No", this.No);
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter();
            sqlDataAdapter1.SelectCommand = sqlCommand1;
            DataTable PostTable = new DataTable();
            SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter();
            sqlDataAdapter2.SelectCommand = sqlCommand2;
            DataTable DempartmentTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter1.Fill(PostTable);
            this.cbx_Post.DataSource = PostTable;
            this.cbx_Post.DisplayMember = "Post";
            this.cbx_Post.ValueMember = "No";
            sqlDataAdapter2.Fill(DempartmentTable);
            this.Cbx_Department.DataSource = DempartmentTable;
            this.Cbx_Department.DisplayMember = "Department";
            this.Cbx_Department.ValueMember = "No";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            byte[] PhotoBytes = null;
            if (sqlDataReader.Read())
            {
                this.Txb_Name.Text = sqlDataReader["Name"].ToString();
                this.rdb_Male.Checked = (bool)sqlDataReader["Gender"];
                this.rdb_female.Checked = !(bool)sqlDataReader["Gender"];
                this.txb_Birthday.Value = (DateTime)sqlDataReader["Birthday"];
                this.Txb_Number.Text = sqlDataReader["Number"].ToString();
                this.cbx_Post.SelectedValue = (int)sqlDataReader["Post"];
                this.Cbx_Department.SelectedValue = (int)sqlDataReader["Department"];
                this.Txb_WorkTime.Value = (DateTime)sqlDataReader["WorkTime"];
                this.Txb_Salary.Text = sqlDataReader["Salary"].ToString();
                PhotoBytes =
                    (sqlDataReader["Photo"] == DBNull.Value ? null : (byte[])sqlDataReader["Photo"]);
            }
            sqlConnection.Close();
            if (PhotoBytes != null)
            {
                MemoryStream memoryStream = new MemoryStream(PhotoBytes);
                this.ptb_Photo.Image = Image.FromStream(memoryStream);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            MemoryStream memoryStream = new MemoryStream();
            this.ptb_Photo.Image.Save(memoryStream, ImageFormat.Bmp);
            byte[] photoBytes = new byte[memoryStream.Length];
            memoryStream.Seek(0, SeekOrigin.Begin);
            memoryStream.Read(photoBytes, 0, photoBytes.Length);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = $@"UPDATE tb_User 
                     SET Name=@Name , Gender=@Gender ,Birthday=@Birthday ,Number=@Number,Department=@Department
                        ,Post=@Post ,WorkTime=@WorkTime ,Salary=@Salary, Photo=@Photo WHERE NO=@No";
            sqlCommand.Parameters.AddWithValue("@No", this.No);
            sqlCommand.Parameters.AddWithValue("@Name", this.Txb_Name.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Gender", this.rdb_Male.Checked);
            sqlCommand.Parameters.AddWithValue("@Birthday", this.txb_Birthday.Value);
            sqlCommand.Parameters.AddWithValue("@Number", this.Txb_Number.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Department", (int)this.Cbx_Department.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@Post", (int)this.cbx_Post.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@WorkTime", this.Txb_WorkTime.Value);
            sqlCommand.Parameters.AddWithValue("@Salary", this.Txb_Salary.Text.Trim());
            sqlCommand.Parameters.AddWithValue("@Photo", photoBytes);
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
            if (row != 0)
            {
                MessageBox.Show($"更新{row}行");
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "打开照片文件"
                ,
                Filter = "图像文件|*.bmp;*.jpg"
                ,
                InitialDirectory = GetFolderPath(SpecialFolder.MyPictures)
            };
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                this.ptb_Photo.Image = Image.FromFile(fileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MedicineManagement medicineManagement = new MedicineManagement(this.No);
            medicineManagement.Show();
            this.Hide();
        } } }


