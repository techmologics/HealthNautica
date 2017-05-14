using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthNautica.Physician.DataAccess.Repositories
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>() where T : class;
        T GetById<T>(int id) where T : class;
        void Insert<T>(T obj) where T : class;
        void Update<T>(T Obj) where T : class;
        void Delete<T>(T Obj) where T : class;
        void Save();
    }
}
