using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthNautica.Physician.DataAccess.Repositories
{
    public class CommonRepository : GenericRepository
    {

        //Need to pass the Dbname
        public CommonRepository() : base(new CommonContext())
        {

        }
    }
}
