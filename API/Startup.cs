using API.Infrastructure;
using AutoMapper;
using BLL.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            
            services.AddAPIServices();

            //DefaultConnection
            //NewConnectionHomePC
            services.AddBLServices(Configuration.GetConnectionString("NewConnectionHomePC"),
                Configuration.GetSection("AppSettings").GetValue<string>("Secret"));

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
