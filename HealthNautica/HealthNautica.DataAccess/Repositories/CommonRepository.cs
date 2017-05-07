using HealthNautica.DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthNautica.DataAccess.Repositories
{
    public class CommonRepository : GenericRepository
    {
        
        //Need to pass the Dbname
        public CommonRepository() : base(new CommonEntities())
        {

        }

        //protected override DbContext DbContext
        //{
        //    get
        //    {
        //        return new DbContexts.CommonEntities();
        //    }

        //}
    }
}
