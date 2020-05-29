using DAL.Context;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly LibraryDataBaseContext _context;
        private readonly ILogger<Repository<T>> _logger;

        public Repository(LibraryDataBaseContext context, ILogger<Repository<T>> logger)
        {
            _context = context;
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }

        public void Add(T item)
        {
            _logger.LogInformation($"{typeof(T)} is added");
            _context.Set<T>().Add(item);
        }

        public void Delete(Guid id)
        {
            var model = FindModelAsync(id).Result;
            if (model == null)
            {
                _logger.LogWarning($"{typeof(T)} not found");
                throw new NullReferenceException($"{typeof(T)} not found");
            }
            _context.Entry<T>(model).State = EntityState.Deleted;
            _context.Set<T>().Remove(model);
            _logger.LogInformation($"{typeof(T)} is deleted");
        }
        public void Edit(T item, Guid id)
        {
            var model = FindModelAsync(id).Result;
            if (model == null)
            {
                _logger.LogWarning($"{typeof(T)} not found");
                throw new NullReferenceException($"{typeof(T)} not found");
            }
            
            Delete(id);
            _logger.LogInformation($"{typeof(T)} is deleted");
            Add(item);
            _logger.LogInformation($"{typeof(T)} is added");
            _logger.LogInformation($"{typeof(T)} is edited");
        }
        public async Task<T> FindModelAsync(Guid id)
        {
            _logger.LogInformation($"{typeof(T)} is finded");
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<T> GetAsync(Guid id)
        {
            _logger.LogInformation($"Return {typeof(T)}");
            return await FindModelAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            _logger.LogInformation($"Return {typeof(T)} list");
            return await _context.Set<T>().ToListAsync<T>();
        }

        public abstract Task<Guid> GetModelIdAsync(string name);

    }
}
