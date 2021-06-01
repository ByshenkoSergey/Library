using DAL.Context;
using DAL.Models;
using DAL.Repository;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class BookRepository : Repository<Book>
    {
        public BookRepository(LibraryDataBaseContext context)
   : base(context) { }

        public override async Task<Guid> GetModelIdAsync(string name)
        {
            var bookList = await GetAllAsync();
            foreach (var book in bookList)
            {
                if (book.BookName == name)
                {
                    return book.BookId;
                }
            }
            return default;
        }
    }
}
