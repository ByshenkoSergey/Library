using DAL.Context;
using DAL.Models;
using DAL.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class BookRepository :Repository<Book>
    {
        private readonly ILogger<BookRepository> _logger;
        public BookRepository(LibraryDataBaseContext context, ILogger<BookRepository> logger)
   : base(context, logger) 
        {
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }
       
        public override async Task<Guid> GetModelIdAsync(string name)
        {
            var bookList = await GetAllAsync();
            foreach (var book in bookList)
            {
                if (book.BookName == name)
                {
                    _logger.LogInformation("Return book id");
                    return book.BookId;
                }
            }

            _logger.LogWarning("Book not found, return default");
            return default;
        }
    }
}
