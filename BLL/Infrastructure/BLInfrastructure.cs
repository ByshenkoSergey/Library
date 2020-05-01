using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.UnitOfWork;
using DAL.Models.IdentityModels;
using BLL.Services.Interfaces;
using BLL.Services;
using BLL.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BLL.Infrastructure.Mapping;

namespace BLL.Infrastructure
{
    public static class BLInfrastructure
    {

        public static void AddBLServises(this IServiceCollection services, string connectionString, string key)
        {
            services.AddScoped<IAuthOptions, AuthOptions>(c => new AuthOptions(key));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMapConfig, MapConfig>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddDbContext<LibraryDataBaseContext>(c => c.UseSqlServer(connectionString), ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            services.AddIdentity<User, UserRole>().AddEntityFrameworkStores<LibraryDataBaseContext>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                 .AddJwtBearer(x =>
                 {
                     x.RequireHttpsMetadata = false;
                     x.SaveToken = true;
                     x.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                         ValidateIssuer = true,
                         ValidIssuer = AuthOptions.issuer,
                         ValidateAudience = true,
                         ValidAudience = AuthOptions.audience,
                         ValidateLifetime = true,
                     };
                 });
        }
    }
}
