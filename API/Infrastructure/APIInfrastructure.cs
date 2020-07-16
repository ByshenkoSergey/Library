using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace API.Infrastructure
{

    /// <summary>
    /// Static class for startup class extension method
    /// </summary>
    public static class APIInfrastructure
    {

        /// <summary>
        /// The extension method in which the connection of versioning and swagger is made to unload startup
        /// </summary>
        /// <param name="services"></param>
        public static void AddAPIServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Library API",
                    Description = "ASP.NET Core Web API"
                });
                c.IncludeXmlComments(GetXmlCommentsPath());
            });

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }

        private static string GetXmlCommentsPath()
        {
            return String.Format(@"{0}\SwaggerLibraryAPI.XML", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
