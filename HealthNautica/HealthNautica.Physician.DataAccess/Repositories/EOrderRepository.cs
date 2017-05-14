using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthNautica.Physician.DataAccess.Repositories
{
    public class EOrderRepository : GenericRepository
    {
        //Need to pass the DbName
        public EOrderRepository() : base(new EOrderContext())
        {

        }
    }
}
