using DAL.Context;
using DAL.Models;
using DAL.Models.IdentityModels;
using DAL.Repository;
using DAL.Repository.Interfaces;
using System;
using System.Threading.Tasks;


namespace DAL.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWorks
    {

        private LibraryDataBaseContext _context;
        private IRepository<Author> _authorRepository;
        private IRepository<Book> _bookRepository;
        private IRepository<PublishingHouse> _publishingHouseRepository;
        private IRepository<ApplicationUserRole> _userRoleRepository;
        private IRepository<ApplicationUser> _userRepository;
        private bool disposed = false;

        public UnitOfWorks(LibraryDataBaseContext context)
        {
            _context = _context ?? context;
        }

        public IRepository<Author> AuthorRepository { get => _authorRepository = _authorRepository ?? new Repository<Author>(_context); }

        public IRepository<Book> BookRepository { get => _bookRepository = _bookRepository ?? new Repository<Book>(_context); }

        public IRepository<PublishingHouse> PublishingHouseRepository { get => _publishingHouseRepository = _publishingHouseRepository ?? new Repository<PublishingHouse>(_context); }

        public IRepository<ApplicationUserRole> UserRoleRepository { get => _userRoleRepository = _userRoleRepository ?? new Repository<ApplicationUserRole>(_context); }

        public IRepository<ApplicationUser> UserRepository { get => _userRepository = _userRepository ?? new Repository<ApplicationUser>(_context); }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
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
