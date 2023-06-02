using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using MedicineAdministration.Bll;
using System.ComponentModel;
using MedicineAdministration.Model;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MedicineAdministration
{
    public partial class Form1 : Form
    {
        private User User { get; set; }
        private IUserBll UserBll { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.txb_No.Validating += this.VaildataUserNo;
            //this.txb_Password.Validating += this.VaildataPassword;
        }
        private byte[] Md5(string plainText)
        {
            byte[] plainBytes = Encoding.Default.GetBytes(plainText);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] cryptedBytes = md5.ComputeHash(plainBytes);
            return cryptedBytes;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string userNo = this.txb_No.Text.Trim();
            byte[] password = Md5(this.txb_Password.Text);
            EduBase eduBase = new EduBase();
            var result =
                from r in eduBase.User
                where r.NO == userNo && r.Password == password
                select r;
            if (result.Count() == 1)
            {
                MedicineManagement medicineManagement = new MedicineManagement();
                medicineManagement.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败");
            }
            //    UserBll = new UserBll();
            //    string userNo = this.txb_No.Text.Trim();
            //    string password = this.txb_Password.Text.Trim();
            //    this.User = this.UserBll.LogIn(userNo, password);
            //    MessageBox.Show(this.UserBll.Message);
            //    if (!this.UserBll.HasLoggedIn)
            //    {
            //        this.txb_Password.Focus();
            //        this.txb_Password.SelectAll();
            //        return;
            //    }
            //    MessageBox.Show($"即将打开{this.User.Name}的主界面!");
            //    MedicineManagement medicineManagement = new MedicineManagement();
            //    medicineManagement.Show();
            //    this.Hide();
        }

        private void SingUp_Click(object sender, EventArgs e)
            {
                string userno = this.txb_No.Text.Trim();
                string password = this.txb_Password.Text.Trim();
                this.User = this.UserBll.SingUp(userno, password); ;
                MessageBox.Show(this.UserBll.Message);
            }
            /// <summary>
            /// 验证用户名
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void VaildataUserNo(object sender, CancelEventArgs e)
            {
                UserBll = new UserBll();
                string userNo = this.txb_No.Text;
                bool isEmpty = string.IsNullOrEmpty(userNo);
                if (isEmpty)
                {
                    this.ErrorProvider.SetError(this.txb_No, "用户名不能为空");
                    return;
                }
                bool isLengthValid =
                    userNo.Length >= this.UserBll.UserNoMinLength
                    && userNo.Length <= this.UserBll.UserNoMaxLength;
                if (!isLengthValid)
                {
                    this.ErrorProvider.SetError(this.txb_No, $"用户名长度应为{this.UserBll.UserNoMinLength}~{this.UserBll.UserNoMaxLength}");
                    return;
                }
                bool isExisting = this.UserBll.CheckExist(userNo); ;
                if (!isExisting)
                {
                    this.ErrorProvider.SetError(this.txb_No, "用户名不存在");
                    return;
                }
                this.ErrorProvider.SetError(this.txb_No, "");
            }
            private void VaildataPassword(object sender, CancelEventArgs e)
            {
                string password = this.txb_Password.Text.Trim();
                bool isEmpty = string.IsNullOrEmpty(password);
                if (isEmpty)
                {
                    this.ErrorProvider.SetError(this.txb_Password, "密码不能为空");
                    return;
                }
                this.ErrorProvider.SetError(this.txb_Password, "");
            }

            private void Form1_Load(object sender, EventArgs e)
            {

            }
        }
    } 
