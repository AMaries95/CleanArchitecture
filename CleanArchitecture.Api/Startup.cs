using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Infrastructure.Data.Context;
using CleanArchitecture.Infrastructure.IoC;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CleanArchitecture.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LearningDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("LearningDbConnection")));

            services.AddControllers();

            services.AddSwaggerGen(
                swagger =>
                {
                    swagger.SwaggerDoc("v1", new OpenApiInfo {Title = "Learning Api", Version = "v1"});
                });
            services.AddMediatR(typeof(Startup));

            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(
                c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Learning Api V1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(IServiceCollection serviceCollection)
        {
            DependencyContainer.RegisterServices(serviceCollection);
        }
    }
}
