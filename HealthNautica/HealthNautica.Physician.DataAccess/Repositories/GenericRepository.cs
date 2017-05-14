using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthNautica.Physician.DataAccess.Repositories
{
    public abstract class GenericRepository : IRepository
    {
        //protected abstract DbContext DbContext { get; }
        private DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }


        public void Delete<T>(T Obj) where T : class
        {
            _context.Set<T>().Remove(Obj);
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }

        //public T GetById<T>(int id) where T : class
        //{
        //    return _context.Set<T>().(id);
        //}

        public void Insert<T>(T obj) where T : class
        {
            _context.Set<T>().Add(obj);
        }

        public void Update<T>(T Obj) where T : class
        {
            _context.Entry<T>(Obj).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
