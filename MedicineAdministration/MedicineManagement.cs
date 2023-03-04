using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.AccessControl;
using static System.Net.WebRequestMethods;
using System.Drawing.Printing;
using MedicineAdministration.Red.Utility.Common.Print;

namespace MedicineAdministration
{
    public partial class MedicineManagement : Form
    {
        public string _No;
        public MedicineManagement()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.LoadTable();
        }
        public MedicineManagement(string no) : this()
        {
            this._No = no;
        }
        private void LoadTable()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = $@"SELECT No AS 编号,MedicineName AS 名称,MedicineClassify AS 分类
             ,Manufacturer AS 生产厂家,Specification 规格,InventoryQuantity AS 数量,Price AS 价格
             , iif (DATEDIFF(DAY,ExpirationTime,GETDATE())>-30,'忽略预警','1') AS 操作 FROM tb_Medicine  
              WHERE DATEDIFF (DAY ,ExpirationTime ,GETDATE ())>-30";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable MedicineTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill(MedicineTable);
            sqlConnection.Close();
            this.Dgv_Medicine.Columns.Clear();
            this.Dgv_Medicine.DataSource = MedicineTable;
        }
        private void MedicineManagement_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = $@"SELECT No AS 编号,MedicineName AS 名称,MedicineClassify AS 分类
             ,Manufacturer AS 生产厂家,Specification 规格,InventoryQuantity AS 数量,Price AS 价格
             , iif (DATEDIFF(DAY,ExpirationTime,GETDATE())>-30,'忽略预警','1') AS 操作 FROM tb_Medicine  
              WHERE DATEDIFF (DAY ,ExpirationTime ,GETDATE ())>-30";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable MedicineTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill(MedicineTable);
            sqlConnection.Close();
            this.Dgv_Medicine.Columns.Clear();
            this.Dgv_Medicine.DataSource = MedicineTable;
        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonalInformation personalInformation = new PersonalInformation(this._No);
            personalInformation.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = $@"SELECT No AS 编号,MedicineName AS 名称,MedicineClassify AS 分类
             ,Manufacturer AS 生产厂家,Specification 规格,InventoryQuantity AS 数量,Price AS 价格
             , iif (DATEDIFF(DAY,ExpirationTime,GETDATE())>-30,'忽略预警','已忽略') AS 操作 FROM tb_Medicine  
              WHERE MedicineName=@MedicineName;";
            sqlCommand.Parameters.AddWithValue("@MedicineName", this.Txb_MedNane.Text.Trim());
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable MedicineTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill(MedicineTable);
            sqlConnection.Close();
            this.Dgv_Medicine.Columns.Clear();
            this.Dgv_Medicine.DataSource = MedicineTable;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PrintDataGridView.Print(Dgv_Medicine, "预警药品单", "");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string result=this.Dgv_Medicine .CurrentRow .Cells["操作"].Value .ToString ();
            if(result == "忽略预警")
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString =
                    ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText =
                       $@"UPDATE tb_Medicine
                        SET ExpirationTime='{2099-10-10}'
                        WHERE NO='{this.Dgv_Medicine.CurrentRow.Cells["编号"].Value.ToString()}'";
                sqlConnection .Open ();
                int row=sqlCommand .ExecuteNonQuery ();
                sqlConnection.Close ();
                if (row != 0)
                {
                    sqlCommand.CommandText =
                        $@"INSERT INTO tb_Medicine1(No ,MedicineName ,MedicineClassify ,Manufacturer ,Specification,InventoryQuantity ,ExpirationTime,Price )
                 VALUES(@No,@MedicineName,@MedicineClassify,@Manufacturer,@Specification,@InventoryQuantity,@ExpirationTime,@Price);";
                    sqlCommand.Parameters.AddWithValue("@No", this.Dgv_Medicine.CurrentRow.Cells["编号"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@MedicineName", this.Dgv_Medicine.CurrentRow.Cells["名称"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@MedicineClassify", this.Dgv_Medicine.CurrentRow.Cells["分类"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@Manufacturer", this.Dgv_Medicine.CurrentRow.Cells["生产厂家"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@Specification", this.Dgv_Medicine.CurrentRow.Cells["规格"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@InventoryQuantity", this.Dgv_Medicine.CurrentRow.Cells["数量"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("@ExpirationTime", "已忽略");
                        sqlCommand.Parameters.AddWithValue("@Price", this.Dgv_Medicine.CurrentRow.Cells["价格"].Value.ToString());
                    sqlConnection.Open();
                    int row1 = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("已忽略");
                    this.LoadTable();
                }
            }
            else
            {
                MessageBox.Show("发生错误！，请联系管理员");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText =
                $@" SELECT No AS 编号,MedicineName AS 名称,MedicineClassify AS 分类,Manufacturer AS 生产商
                  ,Specification AS 规格,InventoryQuantity 数量
                 ,Price AS 价格,ExpirationTime 操作 FROM tb_Medicine1 ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable MedicineTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill(MedicineTable);
            sqlConnection.Close();
            this.Dgv_Medicine.Columns.Clear();
            this.Dgv_Medicine.DataSource = MedicineTable;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = $@"SELECT No AS 编号,MedicineName AS 名称,MedicineClassify AS 分类
             ,Manufacturer AS 生产厂家,Specification 规格,InventoryQuantity AS 数量,Price AS 价格
             , iif (DATEDIFF(DAY,ExpirationTime,GETDATE())>-30,'忽略预警','1') AS 操作 FROM tb_Medicine  
              WHERE DATEDIFF (DAY ,ExpirationTime ,GETDATE ())>-30";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlCommand;
            DataTable MedicineTable = new DataTable();
            sqlConnection.Open();
            sqlDataAdapter.Fill(MedicineTable);
            sqlConnection.Close();
            this.Dgv_Medicine.Columns.Clear();
            this.Dgv_Medicine.DataSource = MedicineTable;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SMS sMS = new SMS();
            sMS .Show ();
        }
    }

    namespace Red.Utility.Common.Print
    {
        public static class PrintDataGridView
        {
            static DataGridView dgv;
            static string titleName = ""; //标题名称       
            static string titleName2 = ""; //第二标题名称     
            static int rowIndex = 0;   //当前行       
            static int page = 1; //当前页      

            static int rowsPerPage = 5;  //每页显示多少行

            private static bool landscape = false;
            /// <summary>
            /// 打印方向 横向true
            /// </summary>
            public static bool Landscape
            {
                get { return PrintDataGridView.landscape; }
                set { PrintDataGridView.landscape = value; }
            }

            /// <summary>
            /// 打印DataGridView
            /// </summary>
            /// <param name="dataGridView">要打印的DataGridView</param>
            /// <param name="title">标题</param>
            /// <param name="title2">第二标题,可以为null</param>
            public static void Print(DataGridView dataGridView, string title, string title2)
            {
                try
                {
                    if (dataGridView == null) { return; }
                    titleName = title;
                    titleName2 = title2;
                    dgv = dataGridView;
                    PrintPreviewDialog ppvw = new PrintPreviewDialog();
                    ppvw.PrintPreviewControl.Zoom = 1.0; //显示比例为100%
                    PrintDocument printDoc = new PrintDocument();
                    PrintDialog MyDlg = new PrintDialog();
                    MyDlg.Document = printDoc;
                    printDoc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
                    printDoc.DefaultPageSettings.Margins = new Margins(15, 30, 60, 60); //设置边距             
                    ppvw.Document = printDoc;   //设置要打印的文档               
                    ((Form)ppvw).WindowState = FormWindowState.Maximized; //最大化               
                    rowIndex = 0; //当前行              
                    page = 1;  //当前页                             
                    printDoc.PrintPage += new PrintPageEventHandler(printDoc_PrintPage); //打印事件 
                    printDoc.EndPrint += new PrintEventHandler(printDoc_EndPrint);
                    ppvw.Document.DefaultPageSettings.Landscape = Landscape;    // 设置打印方向 横向true              
                    ppvw.ShowDialog(); //打开预览

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            static void printDoc_EndPrint(object sender, PrintEventArgs e)
            {
                rowIndex = 0; //当前行          
                page = 1;  //当前页            
                rowsPerPage = 0;//每页显示多少行
            }
            private static void printDoc_PrintPage(object sender, PrintPageEventArgs e)
            {

                //标题字体
                Font titleFont = new Font("微软雅黑", 16, FontStyle.Bold);
                //标题尺寸
                SizeF titleSize = e.Graphics.MeasureString(titleName, titleFont, e.MarginBounds.Width);
                //x坐标
                int x = e.MarginBounds.Left;
                //y坐标
                int y = Convert.ToInt32(e.MarginBounds.Top - titleSize.Height);
                //边距以内纸张宽度
                int pagerWidth = e.MarginBounds.Width;
                //画标题
                e.Graphics.DrawString(titleName, titleFont, Brushes.Black, x + (pagerWidth - titleSize.Width) / 2, y);
                y += (int)titleSize.Height;
                if (titleName2 != null && titleName2 != "")
                {

                    //画第二标题
                    e.Graphics.DrawString(titleName2, dgv.Font, Brushes.Black, x + (pagerWidth - titleSize.Width) / 2 + 200, y);
                    //第二标题尺寸
                    SizeF titleSize2 = e.Graphics.MeasureString(titleName2, dgv.Font, e.MarginBounds.Width);
                    y += (int)titleSize2.Height;

                }

                //表头高度
                int headerHeight = 0;
                //纵轴上 内容与线的距离
                int padding = 6;
                //所有显示列的宽度
                int columnsWidth = 0;
                //计算所有显示列的宽度
                foreach (DataGridViewColumn column in dgv.Columns)
                {

                    //隐藏列返回
                    if (!column.Visible) continue;
                    //所有显示列的宽度
                    columnsWidth += column.Width;
                }

                //计算表头高度
                foreach (DataGridViewColumn column in dgv.Columns)
                {

                    //列宽
                    int columnWidth = (int)(Math.Floor((double)column.Width / (double)columnsWidth * (double)pagerWidth));
                    //表头高度
                    int temp = (int)e.Graphics.MeasureString(column.HeaderText, column.InheritedStyle.Font, columnWidth).Height + 2 * padding;
                    if (temp > headerHeight) headerHeight = temp;
                }

                //画表头

                foreach (DataGridViewColumn column in dgv.Columns)
                {

                    //隐藏列返回
                    if (!column.Visible) continue;
                    //列宽
                    int columnWidth = (int)(Math.Floor((double)column.Width / (double)columnsWidth * (double)pagerWidth));
                    //内容居中要加的宽度
                    float cenderWidth = (columnWidth - e.Graphics.MeasureString(column.HeaderText, column.InheritedStyle.Font, columnWidth).Width) / 2;
                    if (cenderWidth < 0) cenderWidth = 0;
                    //内容居中要加的高度
                    float cenderHeight = (headerHeight + padding - e.Graphics.MeasureString(column.HeaderText, column.InheritedStyle.Font, columnWidth).Height) / 2;
                    if (cenderHeight < 0) cenderHeight = 0;
                    //画背景
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(x, y, columnWidth, headerHeight));
                    //画边框
                    e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, columnWidth, headerHeight));
                    //画上边线

                    //e.Graphics.DrawLine(Pens.Black, x, y, x + columnWidth, y);

                    //画下边线
    
                //e.Graphics.DrawLine(Pens.Black, x, y + headerHeight, x + columnWidth, y + headerHeight);

                //画右边线
    
                //e.Graphics.DrawLine(Pens.Black, x + columnWidth, y, x + columnWidth, y + headerHeight);

                    //if (x == e.MarginBounds.Left)

                    //{

                    //    //画左边线

                    //    e.Graphics.DrawLine(Pens.Black, x, y, x, y + headerHeight);

                    //}

                    //画内容
                e.Graphics.DrawString(column.HeaderText, column.InheritedStyle.Font, new SolidBrush(column.InheritedStyle.ForeColor), new RectangleF(x + cenderWidth, y + cenderHeight, columnWidth, headerHeight));
                    x += columnWidth;

                }

                x = e.MarginBounds.Left;
                y += headerHeight;
                while (rowIndex < dgv.Rows.Count)
                {

                    DataGridViewRow row = dgv.Rows[rowIndex];
                    if (row.Visible)
                    {

                        int rowHeight = 0;
                        foreach (DataGridViewCell cell in row.Cells)
                        {

                            DataGridViewColumn column = dgv.Columns[cell.ColumnIndex];
                            if (!column.Visible || cell.Value == null) continue;
                            int tmpWidth = (int)(Math.Floor((double)column.Width / (double)columnsWidth * (double)pagerWidth));
                            int temp = (int)e.Graphics.MeasureString(cell.Value.ToString(), column.InheritedStyle.Font, tmpWidth).Height + 2 * padding;
                            if (temp > rowHeight) rowHeight = temp;
                        }

                        foreach (DataGridViewCell cell in row.Cells)
                        {

                            DataGridViewColumn column = dgv.Columns[cell.ColumnIndex];
                            if (!column.Visible) continue;
                            int columnWidth = (int)(Math.Floor((double)column.Width / (double)columnsWidth * (double)pagerWidth));
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(x, y, columnWidth, rowHeight));

                            if (cell.Value != null)
                            {

                                //内容居中要加的宽度

                                float cenderWidth = (columnWidth - e.Graphics.MeasureString(cell.Value.ToString(), cell.InheritedStyle.Font, columnWidth).Width) / 2;

                                if (cenderWidth < 0) cenderWidth = 0;

                                //内容居中要加的高度

                                float cenderHeight = (rowHeight + padding - e.Graphics.MeasureString(cell.Value.ToString(), cell.InheritedStyle.Font, columnWidth).Height) / 2;

                                if (cenderHeight < 0) cenderHeight = 0;

                                //画下边线

                                //e.Graphics.DrawLine(Pens.Black, x, y + rowHeight, x + columnWidth, y + rowHeight);

                               // 画右边线
    
                            //e.Graphics.DrawLine(Pens.Black, x + columnWidth, y, x + columnWidth, y + rowHeight);

                                //if (x == e.MarginBounds.Left)

                                //{

                                //    //画左边线

                                //    e.Graphics.DrawLine(Pens.Black, x, y, x, y + rowHeight);

                                //}

                                //画内容

                            e.Graphics.DrawString(cell.Value.ToString(), column.InheritedStyle.Font, new SolidBrush(cell.InheritedStyle.ForeColor), new RectangleF(x + cenderWidth, y + cenderHeight, columnWidth, rowHeight));

                            }

                            x += columnWidth;

                        }

                        x = e.MarginBounds.Left;

                        y += rowHeight;

                        if (page == 1) rowsPerPage++;

                        //打印下一页

                        if (y + rowHeight > e.MarginBounds.Bottom)
                        {

                            e.HasMorePages = true;

                            break;

                        }

                    }

                    rowIndex++;

                }

                //页脚
                string footer = " 第 " + page + " 页，共 " + Math.Ceiling(((double)dgv.Rows.Count / rowsPerPage)).ToString() + " 页";
                //画页脚
                e.Graphics.DrawString(footer, dgv.Font, Brushes.Black, x + (pagerWidth - e.Graphics.MeasureString(footer, dgv.Font).Width) / 2, e.MarginBounds.Bottom);
                page++;

            }
        }

    }

}
 
