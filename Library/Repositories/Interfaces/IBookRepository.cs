using DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IBookRepository 
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookAsync(Guid id);
        Task InsertBookAsync(Book item);
        Task EditBookAsync(Book item, Guid id);
        Task DeleteBookAsync(Guid id);
        Task<Guid> GetBookIdAsync(string item);
    }
}
