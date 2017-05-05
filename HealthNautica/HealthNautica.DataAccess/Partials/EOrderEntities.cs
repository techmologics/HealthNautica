using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthNautica.DataAccess.DbContexts
{
    public partial class EOrderEntities : DbContext
    {
        public EOrderEntities(string existingConnection)
            : base(existingConnection)
        {
        }
    }
}
