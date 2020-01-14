using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace fantasy_bachelor.API
{
    public partial class Startup
    {
        /// <summary>
        /// Cross Origin Resource Sharing (CORS) related configuration for the backend API
        /// </summary>
        /// <param name="services">Passed-in collection of services from ConfigureServices</param>
        public static void ConfigureCorsServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", config =>
                {
                    config
                        //.WithOrigins("http://finalroses.com", "http://www.finalroses.com", "http://localhost:4202")
                        .AllowAnyHeader();
                        config.AllowAnyMethod();
                        config.AllowAnyOrigin();
                        //config.AllowCredentials();
                });
            });
        }

        public static void ConfigureCors(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseCors("AllowAll");
        }
    }
}
