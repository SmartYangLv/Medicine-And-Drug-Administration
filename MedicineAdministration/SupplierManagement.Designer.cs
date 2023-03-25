namespace MedicineAdministration
{
    partial class SupplierManagement
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
            this.dgv_Supper = new System.Windows.Forms.DataGridView();
            this.dgv_Suppers = new System.Windows.Forms.DataGridView();
            this.buttum = new System.Windows.Forms.Button();
            this.退选 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Supper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Suppers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Supper
            // 
            this.dgv_Supper.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Supper.Location = new System.Drawing.Point(186, 12);
            this.dgv_Supper.Name = "dgv_Supper";
            this.dgv_Supper.RowHeadersWidth = 51;
            this.dgv_Supper.RowTemplate.Height = 27;
            this.dgv_Supper.Size = new System.Drawing.Size(913, 271);
            this.dgv_Supper.TabIndex = 0;
            this.dgv_Supper.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgv_Suppers
            // 
            this.dgv_Suppers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Suppers.Location = new System.Drawing.Point(186, 336);
            this.dgv_Suppers.Name = "dgv_Suppers";
            this.dgv_Suppers.RowHeadersWidth = 51;
            this.dgv_Suppers.RowTemplate.Height = 27;
            this.dgv_Suppers.Size = new System.Drawing.Size(913, 327);
            this.dgv_Suppers.TabIndex = 1;
            // 
            // buttum
            // 
            this.buttum.Location = new System.Drawing.Point(1012, 289);
            this.buttum.Name = "buttum";
            this.buttum.Size = new System.Drawing.Size(75, 41);
            this.buttum.TabIndex = 2;
            this.buttum.Text = "选择";
            this.buttum.UseVisualStyleBackColor = true;
            // 
            // 退选
            // 
            this.退选.Location = new System.Drawing.Point(912, 289);
            this.退选.Name = "退选";
            this.退选.Size = new System.Drawing.Size(75, 40);
            this.退选.TabIndex = 3;
            this.退选.Text = "退选";
            this.退选.UseVisualStyleBackColor = true;
            // 
            // SupplierManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 709);
            this.Controls.Add(this.退选);
            this.Controls.Add(this.buttum);
            this.Controls.Add(this.dgv_Suppers);
            this.Controls.Add(this.dgv_Supper);
            this.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SupplierManagement";
            this.Text = "SupplierManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Supper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Suppers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Supper;
        private System.Windows.Forms.DataGridView dgv_Suppers;
        private System.Windows.Forms.Button buttum;
        private System.Windows.Forms.Button 退选;
    }
}