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
        void AddAuthor(Author item);
        void EditAuthor(Author item, Guid id);
        void DeleteAuthor(Guid id);
        Task<Guid> GetAuthorIdAsync(Author item);
       
    }
}
