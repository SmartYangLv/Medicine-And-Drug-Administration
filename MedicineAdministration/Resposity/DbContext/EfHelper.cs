using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace MedicineAdministration.Resposity.DbContext
{
    public  class EfHelper
    {
        public static EduBase GetDbContext()
            =>new EduBase();
        public static int SelectCount<T>(Expression <Func <T ,bool >>match)where T : class
        {
            using (EduBase dbContext =GetDbContext())
            {
                return dbContext.Set<T >().Where(match).Count();
            }
        }
    }
}
