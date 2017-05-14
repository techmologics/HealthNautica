using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthNautica.Physician.DataAccess.Repositories
{
    public class PracticeRepository : GenericRepository
    {
        //Need to pass the Dbname
        //   LocalDataStoreSlot
        //Thread.CurrentPrincipal()
        public PracticeRepository() : base(new PracticeContext())
        {

        }
    }
}
