using DAL.Context;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private LibraryDataBaseContext _context;

        public Repository(LibraryDataBaseContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(Guid id)
        {
            var model = FindModelAsync(id).Result;
            if (model == null)
            {
                throw new NullReferenceException($"{typeof(T)} not found");
            }
            _context.Entry<T>(model).State = EntityState.Deleted;
            _context.Set<T>().Remove(model);
        }
        public void Edit(T item, Guid id)
        {
            var model = FindModelAsync(id).Result;
            if (model == null)
            {
                throw new NullReferenceException($"{typeof(T)} not found");
            }
            Delete(id);
            Add(item);
        }
        public async Task<T> FindModelAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> GetAsync(Guid id)
        {
            return await FindModelAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            
            return await _context.Set<T>().ToListAsync<T>();

        }

        public abstract Task<Guid> GetModelIdAsync(string name);

    }
}
