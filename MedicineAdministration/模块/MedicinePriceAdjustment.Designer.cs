namespace MedicineAdministration
{
    partial class MedicinePriceAdjustment
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
            this.trv_Medicine = new System.Windows.Forms.TreeView();
            this.dgv_Medicine = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_No = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_Manufacturer = new System.Windows.Forms.TextBox();
            this.txt_Specification = new System.Windows.Forms.TextBox();
            this.txt_User = new System.Windows.Forms.TextBox();
            this.txt_Price = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Medicine)).BeginInit();
            this.SuspendLayout();
            // 
            // trv_Medicine
            // 
            this.trv_Medicine.Location = new System.Drawing.Point(12, 54);
            this.trv_Medicine.Name = "trv_Medicine";
            this.trv_Medicine.Size = new System.Drawing.Size(289, 363);
            this.trv_Medicine.TabIndex = 0;
            this.trv_Medicine.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trv_Medicine_AfterSelect);
            // 
            // dgv_Medicine
            // 
            this.dgv_Medicine.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dgv_Medicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Medicine.Location = new System.Drawing.Point(391, 54);
            this.dgv_Medicine.Name = "dgv_Medicine";
            this.dgv_Medicine.RowHeadersWidth = 51;
            this.dgv_Medicine.RowTemplate.Height = 27;
            this.dgv_Medicine.Size = new System.Drawing.Size(387, 363);
            this.dgv_Medicine.TabIndex = 1;
            this.dgv_Medicine.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Medicine_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(812, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "药品编号：";
            // 
            // txt_No
            // 
            this.txt_No.Location = new System.Drawing.Point(923, 51);
            this.txt_No.Name = "txt_No";
            this.txt_No.Size = new System.Drawing.Size(282, 30);
            this.txt_No.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(812, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "药品名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(812, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "药品厂商：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(812, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "药品规格：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(812, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "用法用量：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(812, 364);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "药品价格：";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(923, 112);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(282, 30);
            this.txt_Name.TabIndex = 9;
            // 
            // txt_Manufacturer
            // 
            this.txt_Manufacturer.Location = new System.Drawing.Point(923, 177);
            this.txt_Manufacturer.Name = "txt_Manufacturer";
            this.txt_Manufacturer.Size = new System.Drawing.Size(282, 30);
            this.txt_Manufacturer.TabIndex = 10;
            // 
            // txt_Specification
            // 
            this.txt_Specification.Location = new System.Drawing.Point(923, 241);
            this.txt_Specification.Name = "txt_Specification";
            this.txt_Specification.Size = new System.Drawing.Size(282, 30);
            this.txt_Specification.TabIndex = 11;
            // 
            // txt_User
            // 
            this.txt_User.Location = new System.Drawing.Point(923, 298);
            this.txt_User.Name = "txt_User";
            this.txt_User.Size = new System.Drawing.Size(282, 30);
            this.txt_User.TabIndex = 12;
            // 
            // txt_Price
            // 
            this.txt_Price.Location = new System.Drawing.Point(923, 358);
            this.txt_Price.Name = "txt_Price";
            this.txt_Price.Size = new System.Drawing.Size(282, 30);
            this.txt_Price.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(969, 426);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 46);
            this.button1.TabIndex = 14;
            this.button1.Text = "修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "目录：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(398, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "药品单：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1130, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 17;
            this.button2.Text = "返回";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MedicinePriceAdjustment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 505);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_Price);
            this.Controls.Add(this.txt_User);
            this.Controls.Add(this.txt_Specification);
            this.Controls.Add(this.txt_Manufacturer);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_No);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Medicine);
            this.Controls.Add(this.trv_Medicine);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MedicinePriceAdjustment";
            this.Text = "药物调价";
            this.Load += new System.EventHandler(this.MedicinePriceAdjustment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Medicine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView trv_Medicine;
        private System.Windows.Forms.DataGridView dgv_Medicine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_No;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_Manufacturer;
        private System.Windows.Forms.TextBox txt_Specification;
        private System.Windows.Forms.TextBox txt_User;
        private System.Windows.Forms.TextBox txt_Price;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
    }
}