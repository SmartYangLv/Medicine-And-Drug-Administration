using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MedicineAdministration
{
    public partial class SupplierMaintenance : Form
    {
        public SupplierMaintenance()
        {
            InitializeComponent();
        }

        private void SupplierMaintenance_Load(object sender, EventArgs e)
        {
            //MedicineDrug medicineDrug = new MedicineDrug();
            //var Country = from r in medicineDrug.Country.Include("Area.Medicine")
            //              select r;
            //this.treeView1.Nodes.Clear();

            //foreach (var r in Country)
            //{
            //    TreeNode CountryNode = new TreeNode();
            //    CountryNode.Text = r.Name.ToString();
            //    this.treeView1.Nodes.Add(CountryNode);
            //    foreach (var m in r )
            //    {
            //        TreeNode AreaNode = new TreeNode();
            //        AreaNode.Text =
            //        CountryNode.Nodes.Add(AreaNode);
            //        foreach (DataRow MedicineRow in AreaRow.GetChildRows("Area_Medicine"))
            //        {
            //            TreeNode MedicineNode = new TreeNode();
            //            MedicineNode.Text = MedicineRow["Manufacturer"].ToString();
            //            MedicineNode.Tag = MedicineRow["No"].ToString();
            //            AreaNode.Nodes.Add(MedicineNode);
            //        }
            //    }
            //}

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                ConfigurationManager .ConnectionStrings["sql"].ToString ();
            SqlCommand sqlCommand = sqlConnection.CreateCommand ();
            sqlCommand.CommandText =
                "SELECT *  FROM tb_Country;" +
                "SELECT * FROM tb_Area;" +
                "SELECT * FROM tb_Medicine";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter .SelectCommand = sqlCommand;
            DataSet dataSet = new DataSet();
            sqlConnection .Open ();
            sqlDataAdapter .Fill (dataSet);
            sqlConnection .Close ();
            DataTable CountryTable= dataSet .Tables[0];
            DataTable AreaTable= dataSet.Tables[1];
            DataTable MedicineTable=dataSet.Tables[2];
            DataRelation[] dataRelations =
            {
                new DataRelation
                ("Country_Area",
                CountryTable.Columns ["No"],
                AreaTable .Columns ["CountryNo"]),
                new DataRelation
                ("Area_Medicine",
                AreaTable .Columns ["No"]
                ,MedicineTable .Columns ["AreaNo"])
            };
            dataSet.Relations.AddRange(dataRelations);
            this.treeView1.Nodes .Clear ();
            foreach (DataRow CountryRow in CountryTable .Rows)
            {
                TreeNode CountryNode=new TreeNode ();
                CountryNode .Text = CountryRow["Name"].ToString ();
                CountryNode .Nodes .Add (CountryNode);
                foreach (DataRow AreaRow in CountryRow .GetChildRows("Country_Area"))
                {
                    TreeNode AreaNode=new TreeNode ();
                    AreaNode .Text = AreaRow["Name"].ToString ();
                    CountryNode .Nodes .Add (AreaNode);
                    foreach (DataRow MedicineRow in AreaRow .GetChildRows("Area_Medicine"))
                    {
                        TreeNode MedicineNode=new TreeNode ();
                        MedicineNode .Text = MedicineRow["Manufacturer"].ToString ();
                        MedicineNode .Tag = MedicineRow["NO"];
                        AreaNode .Nodes .Add (MedicineNode);
                    }
                }
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
    
