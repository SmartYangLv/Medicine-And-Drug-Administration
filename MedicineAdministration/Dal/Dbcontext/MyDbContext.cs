using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Npgsql;

namespace MedicineAdministration.Dal.Dbcontext
{
    public abstract  class MyDbContext:DbContext 
    {
        public abstract int SaveChanges(string message);

        public MyDbContext (string MedicineDrug)
            :base(MedicineDrug )
        {
            ;
        }

    }
}
