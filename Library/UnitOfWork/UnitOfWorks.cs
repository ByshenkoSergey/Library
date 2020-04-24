using DAL.Context;
using DAL.Repository;
using DAL.Repository.Interfaces;
using System;
using System.Threading.Tasks;


namespace DAL.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWork
    {

        private LibraryDataBaseContext _context;
        private IAuthorRepository _authorRepository;
        private IBookRepository _bookRepository;
        private IPublishingHouseRepository _publishingHouseRepository;
        private IUserRoleRepository _userRoleRepository;
        private IUserRepository _userRepository;

        public UnitOfWorks(LibraryDataBaseContext context)
        {
            _context = _context ?? context;
        }


        public IAuthorRepository AuthorRepository { get => _authorRepository = _authorRepository ?? new AuthorRepository(_context); }

        public IBookRepository BookRepository { get => _bookRepository = _bookRepository ?? new BookRepository(_context); }

        public IPublishingHouseRepository PublishingHouseRepository { get => _publishingHouseRepository = _publishingHouseRepository ?? new PublishingHouseRepository(_context); }

        public IUserRepository UserRepository { get => _userRepository = _userRepository ?? new UserRepository(_context); }

        public IUserRoleRepository UserRoleRepository { get => _userRoleRepository = _userRoleRepository ?? new UserRoleRepository(_context); }


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


        private bool disposed = false;

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


    }
}
