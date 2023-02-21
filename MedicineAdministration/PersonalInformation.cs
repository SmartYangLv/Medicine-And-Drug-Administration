using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace MedicineAdministration
{
    public partial class PersonalInformation : Form
    {
        public string  No;
        public PersonalInformation()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        public PersonalInformation (string no):this () 
        {
            this.No = no;
        }

        private void Personal_Information_Load(object sender, EventArgs e)
        {
            SqlConnection sqlConnection =new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = $@"SELECT * FROM tb_User WHERE NO=@No;";
            sqlCommand.Parameters.AddWithValue("@No", this.No);
            sqlConnection .Open ();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader ();
            if(sqlDataReader.Read ())
            {
                this.Txb_Name.Text = sqlDataReader["Name"].ToString ();
                this.Txb_Gender .Text =sqlDataReader["Gender"].ToString ();
                this.txb_Birthday.Value =(DateTime )sqlDataReader["Birthday"];
                this.Txb_Number .Text =sqlDataReader["Number"].ToString();
                this.Txb_Department .Text =sqlDataReader["Department"].ToString ();
                this.Txb_Post .Text =sqlDataReader["Post"].ToString ();
            }
            sqlConnection.Close ();
        }
    }
}
