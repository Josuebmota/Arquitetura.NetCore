using App.Src.Config.Environments;
using App.Src.Shared.Infra.Data.Connection;
using App.Src.Shared.Infra.Data.Connection.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace App.Src.Shared.Infra.CrossCutting.Ioc.Factorys
{
    public static class ConnectionDbFactory 
    {
        public static IServiceCollection RegisterDbConnections(this IServiceCollection connections)
        {
            SqlConnectionFactory ConnectionOne = new(Constants.APPLICATION_NAME, Constants.HOST, Constants.DATABASE, Constants.USER, Constants.PASS);

            ConnectionsDb connecionFactory = new()
            {
                ConnectionOne = ConnectionOne,
            };

            connections.AddTransient<IConnectionsDb>(_ => connecionFactory);

            return connections;
        }
    }
}
