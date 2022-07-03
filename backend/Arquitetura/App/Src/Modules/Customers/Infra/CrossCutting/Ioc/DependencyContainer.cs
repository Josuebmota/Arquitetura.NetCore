using App.Src.Modules.CustomerOutDated.Domain.Interfaces.Repositories;
using App.Src.Modules.CustomerOutDated.Domain.Interfaces.Services;
using App.Src.Modules.Customers.Infra.Data.Repositories.Dapper;
using App.Src.Modules.Customers.Services;
using Microsoft.Extensions.DependencyInjection;

namespace App.Src.Modules.Customers.Infra.CrossCutting.Ioc
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterCustomersRepositories(this IServiceCollection repositories)
        {
            repositories.AddSingleton<IClientsRepository, ClientsRepository>();

            return repositories;
        }

        public static IServiceCollection RegisterCustomersServices(this IServiceCollection services)
        {
            services.AddSingleton<IInsertClientService, InsertClientService>();
            services.AddSingleton<IUpdateClientService, UpdateClientService>();

            return services;
        }
    }
}
