using System;
using System.Collections.Generic;
using System.Linq;
using KeepItDRY.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeepItDRY.DAL
{
    public abstract class BaseRepository<T>: IRepository<T> where T : class, IEntity
    {
        private protected readonly KeepItDRYContext _context;

        public BaseRepository(KeepItDRYContext context)
        {
            _context = context ?? throw new ArgumentNullException("DbContext");
        }

        // Move to Unit Testing
        //private Repository()
        //{
        //    var inMemoryBuilder = new DbContextOptionsBuilder<KeepItDRYContext>();
        //    inMemoryBuilder.UseInMemoryDatabase("KeepItDRY");
        //    _context = new KeepItDRYContext(inMemoryBuilder.Options);
        //}

        public T Get(int Id) => _context.Find<T>(Id);

        public List<T> GetListByAll() => _context.Set<T>().ToList();

        public bool Exists(int Id) => _context.Set<T>().Any(o => o.Id == Id);

        public int Update(T obj)
        {
            _context.Entry(obj).State = (obj.Id <= 0) ? EntityState.Added : EntityState.Modified;
            try
            {
                _context.SaveChanges();
                return obj.Id;
            }
            catch
            {
                _context.Entry(obj).State = EntityState.Detached;
                throw;
            }
        }

        public void Delete(int Id)
        {
            T obj = Get(Id);
            var prevState = _context.Entry(obj).State;
            _context.Entry(obj).State = EntityState.Deleted;
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                _context.Entry(obj).State = prevState;
                throw;
            }
        }

    }
}
