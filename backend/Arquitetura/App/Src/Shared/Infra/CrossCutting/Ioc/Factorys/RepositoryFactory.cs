using App.Src.Modules.Customers.Infra.CrossCutting.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace App.Src.Shared.Infra.CrossCutting.Ioc.Factorys
{
    public static class RepositoryFactory 
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection repositories)
        {
            repositories.RegisterCustomersRepositories();

            return repositories;
        }
    }
}
