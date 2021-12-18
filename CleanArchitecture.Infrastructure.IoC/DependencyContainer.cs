using CleanArchitecture.ApplicationCore.Interfaces;
using CleanArchitecture.ApplicationCore.Services;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            // application layer
            serviceCollection.AddScoped<ICourseService, CourseService>();

            // infrastructure.data layer
            serviceCollection.AddScoped<ICourseRepository, CourseRepository>();
        }
    }
}