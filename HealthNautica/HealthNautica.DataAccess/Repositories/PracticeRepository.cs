using HealthNautica.DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HealthNautica.DataAccess.Repositories
{
    public class PracticeRepository : GenericRepository
    {
        //Need to pass the Dbname
        //   LocalDataStoreSlot
        //Thread.CurrentPrincipal()
        public PracticeRepository() : base(new PracticeEntities())
        {

        }
        //protected override DbContext DbContext
        //{
        //    get
        //    {
        //        return new DbContexts.PracticeEntities();
        //    }
        //}
    }
}
