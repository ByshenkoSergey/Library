using DAL.Context;
using DAL.Models;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class BookRepository : IBookRepository
    {
        private LibraryDataBaseContext _context;


        public BookRepository(LibraryDataBaseContext context)
        {
           _context = context;
        }

        public void DeleteBook(Guid id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                throw new NullReferenceException("Book not found");
            }
            _context.Entry<Book>(book).State = EntityState.Deleted;
            _context.Books.Remove(book);
        }


        public void EditBook(Book item, Guid id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                throw new NullReferenceException("Book not found");
            }
            DeleteBook(id);
            AddBook(item);
        }


        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }


        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync<Book>();
        }


        public void AddBook(Book item)
        {
            _context.Books.Add(item);
        }


        public async Task<Guid> GetBookIdAsync(string bookName)
        {
            var books = await GetAllBooksAsync();

            foreach (var book in books)
            {
                if (book.BookName == bookName)
                    return book.BookId;
            }

            return default;

        }


    }
}
