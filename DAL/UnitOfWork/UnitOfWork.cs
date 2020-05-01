﻿using DAL.Context;
using DAL.Models;
using DAL.Models.IdentityModels;
using DAL.Repositories;
using DAL.Repository;
using DAL.Repository.Interfaces;
using System;
using System.Threading.Tasks;


namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private LibraryDataBaseContext _context;
        private IRepository<Author> _authorRepository;
        private IRepository<Book> _bookRepository;
        private IRepository<Publisher> _PublisherRepository;
        private IRepository<UserRole> _userRoleRepository;
        private IRepository<User> _userRepository;
        private bool disposed = false;

        public UnitOfWork(LibraryDataBaseContext context)
        {
            _context = _context ?? context;
        }

        public IRepository<Author> AuthorRepository { get => _authorRepository = _authorRepository ?? new AuthorRepository(_context); }

        public IRepository<Book> BookRepository { get => _bookRepository = _bookRepository ?? new BookRepository(_context); }

        public IRepository<Publisher> PublisherRepository { get => _PublisherRepository = _PublisherRepository ?? new PublisherRepository(_context); }

        public IRepository<UserRole> UserRoleRepository { get => _userRoleRepository = _userRoleRepository ?? new UserRoleRepository(_context); }

        public IRepository<User> UserRepository { get => _userRepository = _userRepository ?? new UserRepository(_context); }

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
