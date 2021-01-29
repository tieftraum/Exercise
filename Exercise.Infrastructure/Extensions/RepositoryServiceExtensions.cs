using AutoMapper.Configuration;
using Exercise.Domain.Interfaces;
using Exercise.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Exercise.Infrastructure.Extensions
{
    public static class RepositoryServiceExtensions
    {
        public static IServiceCollection InjectRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}