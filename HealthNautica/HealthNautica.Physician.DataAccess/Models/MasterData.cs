using System;
using System.Collections.Generic;

namespace HealthNautica.Physician.DataAccess
{
    public partial class MasterData
    {
        public int Id { get; set; }
        public string DbName { get; set; }
        public string Hospital { get; set; }
    }
}
