using Microsoft.Extensions.DependencyInjection;
using BL.Service.Interfaces;
using BL.Service;

namespace BL
{
    public static class APILaerInfrastructure
    {
        public static void AddAPILaerServices(this IServiceCollection service)
        {
            service.AddScoped<IAuthorService, AuthorService>();
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IPublishingHouseService, PublishingHouseService>();
        }
    }
}
