using DAL.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        IPublishingHouseRepository PublishingHouseRepository { get; }
        IUserRepository UserRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        Task SaveChangeAsync();
    }
}
