using Microsoft.Extensions.DependencyInjection;
using BLL.Services.Interfaces;
using BLL.Services;

namespace API.Infrastructure
{
    public static class APILaerInfrastructure
    {
        public static void AddAPILaerServices(this IServiceCollection service)
        {
            service.AddScoped<IAuthorService, AuthorService>();
            service.AddScoped<IBookService, BookService>();
            service.AddScoped<IPublisherService, PublisherService>();
        }
    }
}
