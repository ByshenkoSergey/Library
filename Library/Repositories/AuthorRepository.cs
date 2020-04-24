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
            this._context = context;
        }

        public async Task DeleteAuthorAsync(Guid id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                throw new NullReferenceException("Author not found");
            }
            _context.Entry<Author>(author).State = EntityState.Deleted;
            _context.Authors.Remove(author);
        }


        public async Task EditAuthorAsync(Author item, Guid id)
        {

            var author = await _context.Authors.FindAsync(id);

            if (author == null)
            {
                throw new NullReferenceException("Author not found");
            }

            await DeleteAuthorAsync(id);
            await _context.SaveChangesAsync();
            await _context.Authors.AddAsync(item);
        }



        public async Task<Author> GetAuthorAsync(Guid id)
        {
            return await _context.Authors.FindAsync(id);
        }


        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync<Author>();
        }


        public async Task InsertAuthorAsync(Author item)
        {
            await _context.Authors.AddAsync(item);
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
