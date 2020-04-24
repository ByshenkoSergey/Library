using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.UnitOfWork;
using DAL.Models.IdentityModels;
using BL.Service.Interfaces;
using BL.Service;

namespace BL.Infrastructure
{
    public static class BLInfrastructure
    {
        public static void AddBLServises(this IServiceCollection service, string connectionString)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IMapConfig, MapConfig>();
            service.AddScoped<IUnitOfWork, UnitOfWorks>();
            service.AddDbContext<LibraryDataBaseContext>(c => c.UseSqlServer(connectionString), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            service.AddIdentity<ApplicationUser, ApplicationUserRole>().AddEntityFrameworkStores<LibraryDataBaseContext>();
        }
    }
}
