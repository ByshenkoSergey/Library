using DAL.Context;
using DAL.Models;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private LibraryDataBaseContext _context;

        public AuthorRepository(LibraryDataBaseContext context)
        {
            _context = context;
        }

        public void DeleteAuthor(Guid id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
            {
                throw new NullReferenceException("Author not found");
            }
            _context.Entry<Author>(author).State = EntityState.Deleted;
            _context.Authors.Remove(author);
        }
        public void EditAuthor(Author item, Guid id)
        {
            var author = _context.Authors.Find(id);
            if (author == null)
            {
                throw new NullReferenceException("Author not found");
            }

            DeleteAuthor(id);
            AddAuthor(item);
        }
        public async Task<Author> GetAuthorAsync(Guid id)
        {
            return await _context.Authors.FindAsync(id);
        }


        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync<Author>();
        }


        public void AddAuthor(Author item)
        {
            _context.Authors.Add(item);
        }
        public async Task<Guid> GetAuthorIdAsync(Author item)
        {

            var authors = await GetAllAuthorsAsync();


            foreach (var author in authors)
            {
                if (author == item)
                    return author.AuthorId;
            }
            return default;
        }
    }

}
