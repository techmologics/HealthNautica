using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthNautica.Physician.DataAccess.Repositories;
using HealthNautica.Physician.DataAccess;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthNautica.Controllers
{
    [Route("api/[controller]")]
    public class EOrderController : Controller
    {
        private readonly IRepository _eOrderRepository;
        public EOrderController()
        {
            _eOrderRepository = new EOrderRepository();
        }
        [HttpGet]
        public bool EOrderSaveTest()
        {
            try
            {
                _eOrderRepository.Insert<Eorder>(new Eorder
                {
                    Id = 10,
                    Name = "Papolu"
                });
                _eOrderRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
