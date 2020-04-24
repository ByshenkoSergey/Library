using DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IAuthorRepository 
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorAsync(Guid id);
        Task InsertAuthorAsync(Author item);
        Task EditAuthorAsync(Author item, Guid id);
        Task DeleteAuthorAsync(Guid id);
        Task<Guid> GetAuthorIdAsync(Author item);
       
    }
}
