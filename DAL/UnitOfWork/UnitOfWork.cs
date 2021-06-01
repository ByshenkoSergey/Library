using DAL.Context;
using DAL.Models;
using DAL.Models.IdentityModels;
using DAL.Repositories;
using DAL.Repository.Interfaces;
using System;
using System.Threading.Tasks;


namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDataBaseContext _context;
        private IRepository<Author> _authorRepository;
        private IRepository<Book> _bookRepository;
        private IRepository<Publisher> _publisherRepository;
        private IRepository<UserRole> _userRoleRepository;
        private IRepository<User> _userRepository;
        private bool _disposed = false;

        public UnitOfWork(LibraryDataBaseContext context)
        {
            _context ??= context;
        }

        public IRepository<Author> AuthorRepository { get => _authorRepository ??= new AuthorRepository(_context); }

        public IRepository<Book> BookRepository { get => _bookRepository ??= new BookRepository(_context); }

        public IRepository<Publisher> PublisherRepository { get => _publisherRepository ??= new PublisherRepository(_context); }

        public IRepository<UserRole> UserRoleRepository { get => _userRoleRepository ??= new UserRoleRepository(_context); }

        public IRepository<User> UserRepository { get => _userRepository ??= new UserRepository(_context); }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public async Task SaveChangeAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
