using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAdministration
{
    public class User
    {
        public string No;
        public byte[] Password;
        public bool IsActivated;
        public int LoginFailCount;
        public string UserName;
    }
}
