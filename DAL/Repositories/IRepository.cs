using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T item);
        void Delete(Guid id);
        void Edit(T item, Guid id);
        Task<T> FindModelAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
    }
}
