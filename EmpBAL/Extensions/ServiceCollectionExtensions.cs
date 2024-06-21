using EmpBAL.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace EmpBAL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BusinessAccessLayerProfile).Assembly);
           
            return services;
        }
    }
}
