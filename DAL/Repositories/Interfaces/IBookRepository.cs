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
        void AddBook(Book item);
        void EditBook(Book item, Guid id);
        void DeleteBook(Guid id);
        Task<Guid> GetBookIdAsync(string item);
    }
}
