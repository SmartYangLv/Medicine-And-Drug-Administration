﻿namespace MedicineAdministration
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_No = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txb_Password = new System.Windows.Forms.TextBox();
            this.SingUp = new System.Windows.Forms.Button();
            this.Lab_No = new System.Windows.Forms.Label();
            this.LabPaw = new System.Windows.Forms.Label();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 343);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(255, 142);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "账号：";
            // 
            // txb_No
            // 
            this.txb_No.Location = new System.Drawing.Point(351, 132);
            this.txb_No.Name = "txb_No";
            this.txb_No.Size = new System.Drawing.Size(197, 30);
            this.txb_No.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码：";
            // 
            // txb_Password
            // 
            this.txb_Password.Location = new System.Drawing.Point(351, 231);
            this.txb_Password.Name = "txb_Password";
            this.txb_Password.PasswordChar = '*';
            this.txb_Password.Size = new System.Drawing.Size(197, 30);
            this.txb_Password.TabIndex = 4;
            // 
            // SingUp
            // 
            this.SingUp.Location = new System.Drawing.Point(472, 343);
            this.SingUp.Name = "SingUp";
            this.SingUp.Size = new System.Drawing.Size(109, 45);
            this.SingUp.TabIndex = 5;
            this.SingUp.Text = "注册";
            this.SingUp.UseVisualStyleBackColor = true;
            this.SingUp.Click += new System.EventHandler(this.SingUp_Click);
            // 
            // Lab_No
            // 
            this.Lab_No.AutoSize = true;
            this.Lab_No.ForeColor = System.Drawing.Color.Red;
            this.Lab_No.Location = new System.Drawing.Point(554, 142);
            this.Lab_No.Name = "Lab_No";
            this.Lab_No.Size = new System.Drawing.Size(0, 20);
            this.Lab_No.TabIndex = 6;
            // 
            // LabPaw
            // 
            this.LabPaw.AutoSize = true;
            this.LabPaw.ForeColor = System.Drawing.Color.Red;
            this.LabPaw.Location = new System.Drawing.Point(554, 241);
            this.LabPaw.Name = "LabPaw";
            this.LabPaw.Size = new System.Drawing.Size(0, 20);
            this.LabPaw.TabIndex = 7;
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 524);
            this.Controls.Add(this.LabPaw);
            this.Controls.Add(this.Lab_No);
            this.Controls.Add(this.SingUp);
            this.Controls.Add(this.txb_Password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txb_No);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "医药管理系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_No;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txb_Password;
        private System.Windows.Forms.Button SingUp;
        private System.Windows.Forms.Label Lab_No;
        private System.Windows.Forms.Label LabPaw;
        public System.Windows.Forms.ErrorProvider ErrorProvider;
    }
}

