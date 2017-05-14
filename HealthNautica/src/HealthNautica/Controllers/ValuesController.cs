using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HealthNautica.Physician.Services;
using HealthNautica.Physician.DataAccess.Repositories;
using HealthNautica.Physician.DataAccess;
using System.Linq;
using System;

namespace HealthNautica.Physician.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IRepository _commonRepository;
        private readonly IRepository _practiceRepository;
        private readonly IRepository _eOrderRepository;
        public ValuesController()
        {
            _commonRepository = new CommonRepository();
            _practiceRepository = new PracticeRepository();
            _eOrderRepository = new EOrderRepository();
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    var load = HttpContext.Items["payload"] as AuthOptions;
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        public string CommonTest()
        {
            return _commonRepository.GetAll<MasterData>().FirstOrDefault().DbName;
        }

        //[HttpGet]
        //public bool EOrderSaveTest()
        //{
        //    try
        //    {
        //        _eOrderRepository.Insert<Eorder>(new Eorder
        //        {
        //            Id = 10,
        //            Name = "Papolu"
        //        });
        //        _eOrderRepository.Save();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //[HttpGet]
        //public bool PracticeSaveTest()
        //{
        //    try
        //    {
        //        _practiceRepository.Insert<Practice>(new Practice
        //        {
        //            Id = 10,
        //            Name = "Papolu"
        //        });
        //        _practiceRepository.Save();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}


    }
}
