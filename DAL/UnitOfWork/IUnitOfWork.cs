using DAL.Models;
using DAL.Models.IdentityModels;
using DAL.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Author> AuthorRepository { get; }
        IRepository<Book> BookRepository { get; }
        IRepository<PublishingHouse> PublishingHouseRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<UserRole> UserRoleRepository { get; }

        Task SaveChangeAsync();
    }
}