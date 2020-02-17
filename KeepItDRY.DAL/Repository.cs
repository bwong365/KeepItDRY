using System;
using System.Collections.Generic;
using System.Linq;
using KeepItDRY.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace KeepItDRY.DAL
{
    public class Repository<T> where T : class, IEntity, IRepository<T>
    {
        private readonly KeepItDRYContext _context;

        public static Repository<T> CreateRepository(string connectionString) => new Repository<T>(connectionString);

        public static Repository<T> CreateTestRepository() => new Repository<T>();

        private Repository(string connectionString)
        {
            var sqlBuilder = new DbContextOptionsBuilder<KeepItDRYContext>();
            sqlBuilder.UseSqlServer(connectionString);
            _context = new KeepItDRYContext(sqlBuilder.Options);
        }

        private Repository()
        {
            var inMemoryBuilder = new DbContextOptionsBuilder<KeepItDRYContext>();
            inMemoryBuilder.UseInMemoryDatabase("KeepItDRY");
            _context = new KeepItDRYContext(inMemoryBuilder.Options);
        }

        public T Get(int Id) => _context.Find<T>(Id);

        public List<T> GetListByAll() => _context.Set<T>().ToList();

        public void Update(T obj)
        {
            _context.Entry(obj).State = (obj.Id <= 0) ? EntityState.Added : EntityState.Modified;
            try
            {
                _context.SaveChanges();
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
