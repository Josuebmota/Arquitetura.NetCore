using App.Src.Modules.CustomerOutDated.Domain.Interfaces.Repositories;
using App.Src.Modules.Customers.Domain.Dtos;
using App.Src.Modules.Customers.Domain.Models;
using App.Src.Modules.Customers.Infra.Data.Repositories.Dapper.Querys;
using App.Src.Shared.Infra.Data.Connection.Interface;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Threading.Tasks;

namespace App.Src.Modules.Customers.Infra.Data.Repositories.Dapper
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly ILogger<ClientsRepository> _logger;
        private readonly IConnectionFactory connectionFactory;
        public ClientsRepository(ILogger<ClientsRepository> logger,
            IConnectionsDb connectionsDb)
        {
            _logger = logger;
            connectionFactory = connectionsDb.ConnectionOne;
        }
        public async Task Insert(InsertClientDto data)
        {
            using IDbConnection connection = connectionFactory.CreateConnectionOpened();
            using IDbTransaction transaction = connection.BeginTransaction();
            try
            {
                var result = await connection.ExecuteAsync
                    (ClientsQuery.Insert, data, transaction, commandTimeout: 0);
                connection.Close();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                connection.Close();
                transaction.Rollback();
                _logger.LogError("Erro Insert");
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<Clients> FindByClientId(int clientId)
        {
            using IDbConnection connection = connectionFactory.CreateConnectionOpened();
            try
            {
                var result = await connection.QueryFirstOrDefaultAsync<Clients>
                    (ClientsQuery.FindByClientId, new { ClientId = clientId }, commandTimeout: 0);
                connection.Close();
                return result;
            }
            catch (Exception ex)
            {
                connection.Close();
                _logger.LogError("Erro FindByClientId");
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Clients> FindByEmail(string email)
        {
            using IDbConnection connection = connectionFactory.CreateConnectionOpened();
            try
            {
                var result = await connection.QueryFirstOrDefaultAsync<Clients>
                    (ClientsQuery.FindByEmail, new { Email = email }, commandTimeout: 0);
                connection.Close();
                return result;
            }
            catch (Exception ex)
            {
                connection.Close();
                _logger.LogError("Erro FindByEmail");
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task Update(UpdateClientDto data)
        {
            using IDbConnection connection = connectionFactory.CreateConnectionOpened();
            using IDbTransaction transaction = connection.BeginTransaction();
            try
            {
                var result = await connection.ExecuteAsync
                    (ClientsQuery.Insert, data, transaction, commandTimeout: 0);
                connection.Close();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                connection.Close();
                transaction.Rollback();
                _logger.LogError("Erro Update");
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task Delete(int clientId)
        {
            using IDbConnection connection = connectionFactory.CreateConnectionOpened();
            using IDbTransaction transaction = connection.BeginTransaction();
            try
            {
                var result = await connection.ExecuteAsync
                    (ClientsQuery.Insert, new { ClientId = clientId }, transaction, commandTimeout: 0);
                connection.Close();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                connection.Close();
                transaction.Rollback();
                _logger.LogError("Erro Delete");
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
