using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthNautica.Physician.DataAccess;
using HealthNautica.Physician.DataAccess.Repositories;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthNautica.Controllers
{
    [Route("api/[controller]")]
    public class PracticeController : Controller
    {
        private readonly IRepository _practiceRepository;
        public PracticeController()
        {
            _practiceRepository = new PracticeRepository();
        }
        [HttpGet]
        public bool PracticeSaveTest()
        {
            try
            {
                _practiceRepository.Insert<Practice>(new Practice
                {
                    Id = 10,
                    Name = "Papolu"
                });
                _practiceRepository.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
