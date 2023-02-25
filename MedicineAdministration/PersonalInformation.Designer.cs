namespace MedicineAdministration
{
    partial class PersonalInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Txb_Name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txb_Gender = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Txb_Number = new System.Windows.Forms.TextBox();
            this.Txb_Post = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Txb_Department = new System.Windows.Forms.TextBox();
            this.txb_Birthday = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Txb_WorkTime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.Txb_Salary = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // Txb_Name
            // 
            this.Txb_Name.Location = new System.Drawing.Point(288, 94);
            this.Txb_Name.Name = "Txb_Name";
            this.Txb_Name.Size = new System.Drawing.Size(190, 30);
            this.Txb_Name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "性别：";
            // 
            // Txb_Gender
            // 
            this.Txb_Gender.Location = new System.Drawing.Point(288, 166);
            this.Txb_Gender.Name = "Txb_Gender";
            this.Txb_Gender.Size = new System.Drawing.Size(190, 30);
            this.Txb_Gender.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "出生日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(548, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "职务：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(552, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "工号：";
            // 
            // Txb_Number
            // 
            this.Txb_Number.Location = new System.Drawing.Point(630, 98);
            this.Txb_Number.Name = "Txb_Number";
            this.Txb_Number.Size = new System.Drawing.Size(201, 30);
            this.Txb_Number.TabIndex = 8;
            // 
            // Txb_Post
            // 
            this.Txb_Post.Location = new System.Drawing.Point(630, 170);
            this.Txb_Post.Name = "Txb_Post";
            this.Txb_Post.Size = new System.Drawing.Size(201, 30);
            this.Txb_Post.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(510, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "工作部门：";
            // 
            // Txb_Department
            // 
            this.Txb_Department.Location = new System.Drawing.Point(630, 241);
            this.Txb_Department.Name = "Txb_Department";
            this.Txb_Department.Size = new System.Drawing.Size(201, 30);
            this.Txb_Department.TabIndex = 11;
            // 
            // txb_Birthday
            // 
            this.txb_Birthday.Location = new System.Drawing.Point(288, 233);
            this.txb_Birthday.Name = "txb_Birthday";
            this.txb_Birthday.Size = new System.Drawing.Size(190, 30);
            this.txb_Birthday.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(440, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 58);
            this.button1.TabIndex = 13;
            this.button1.Text = "信息更改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "工作日期：";
            // 
            // Txb_WorkTime
            // 
            this.Txb_WorkTime.Location = new System.Drawing.Point(287, 298);
            this.Txb_WorkTime.Name = "Txb_WorkTime";
            this.Txb_WorkTime.Size = new System.Drawing.Size(191, 30);
            this.Txb_WorkTime.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(514, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "基本工资：";
            // 
            // Txb_Salary
            // 
            this.Txb_Salary.Location = new System.Drawing.Point(630, 302);
            this.Txb_Salary.Name = "Txb_Salary";
            this.Txb_Salary.Size = new System.Drawing.Size(201, 30);
            this.Txb_Salary.TabIndex = 17;
            // 
            // PersonalInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 527);
            this.Controls.Add(this.Txb_Salary);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Txb_WorkTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txb_Birthday);
            this.Controls.Add(this.Txb_Department);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Txb_Post);
            this.Controls.Add(this.Txb_Number);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Txb_Gender);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txb_Name);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PersonalInformation";
            this.Text = "个人信息";
            this.Load += new System.EventHandler(this.Personal_Information_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txb_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txb_Gender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Txb_Number;
        private System.Windows.Forms.TextBox Txb_Post;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txb_Department;
        private System.Windows.Forms.DateTimePicker txb_Birthday;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker Txb_WorkTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Txb_Salary;
    }
}