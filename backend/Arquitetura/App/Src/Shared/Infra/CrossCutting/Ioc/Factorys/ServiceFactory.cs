using App.Src.Modules.Customers.Infra.CrossCutting.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace App.Src.Shared.Infra.CrossCutting.Ioc.Factorys
{
    public static class ServiceFactory
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.RegisterCustomersServices();

            return services;
        }

    }
}
