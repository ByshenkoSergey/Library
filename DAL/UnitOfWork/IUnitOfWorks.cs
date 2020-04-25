using DAL.Models;
using DAL.Models.IdentityModels;
using DAL.Repository.Interfaces;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWorks
    {
        IRepository<Author> AuthorRepository { get; }
        IRepository<Book> BookRepository { get; }
        IRepository<PublishingHouse> PublishingHouseRepository { get; }
        IRepository<ApplicationUser> UserRepository { get; }
        IRepository<ApplicationUserRole> UserRoleRepository { get; }

        Task SaveChangeAsync();
    }
}