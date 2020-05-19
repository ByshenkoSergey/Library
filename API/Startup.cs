using AutoMapper;
using BLL.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;


namespace API_Laer
{
    /// <summary>
    /// Application setup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Dependency injection in Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Property
        /// </summary>
        public IConfiguration Configuration { get; }


        /// <summary>
        /// Configuring services for further dependency injection
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors();
            services.AddControllers();
            services.AddMvc();
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

            //DefaultConnection
            //NewConnectionHomePC
            services.AddBLServises(Configuration.GetConnectionString("NewConnectionHomePC"),
                Configuration.GetSection("AppSettings").GetValue<string>("Secret"));


        }

        private static string GetXmlCommentsPath()
        {
            return String.Format(@"{0}\SwaggerLibraryAPI.XML", AppDomain.CurrentDomain.BaseDirectory);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        /// <summary>
        /// Ñonnection and adjustment of conveyors middleware
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Library API V1");
            });

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
