using CleanArchitecture.ApplicationCore.Interfaces;
using CleanArchitecture.ApplicationCore.Services;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Commands;
using CleanArchitecture.Domain.Core.Bus;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Data.Context;
using CleanArchitecture.Infrastructure.Data.Repository;
using Infrastructure.Bus;
using MediatR;
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
            serviceCollection.AddScoped<LearningDbContext>();

            // domain InMemory MediatR bus
            serviceCollection.AddScoped<IMediatorHandler, MediatorHandler>();

            // domain handlers
            serviceCollection.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();
        }
    }
}