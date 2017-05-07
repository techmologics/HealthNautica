using HealthNautica.DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthNautica.DataAccess.Repositories
{
    public class EOrderRepository : GenericRepository
    {
        //Need to pass the DbName
        public EOrderRepository() : base(new EOrderEntities())
        {

        }
    }
}
