using App.Src.Modules.CustomerOutDated.Domain.Interfaces.Repositories;
using App.Src.Modules.CustomerOutDated.Domain.Interfaces.Services;
using App.Src.Modules.Customers.Domain.Dtos;
using App.Src.Modules.Customers.Domain.Models;
using App.Src.Shared.Application.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace App.Src.Modules.Customers.Services
{
    public class InsertClientService : IInsertClientService
    {
        private readonly ILogger<InsertClientService> _logger;
        private IClientsRepository ClientsRepository { get; set; }
        public InsertClientService(ILogger<InsertClientService> logger
            , IClientsRepository clientsRepository)
        {
            _logger = logger;
            ClientsRepository = clientsRepository;
        }

        public async Task<Clients> Execute(InsertClientDto data)
        {
            try
            {
                Clients clients = await ClientsRepository.FindByEmail(data.Email);

                if(clients is not null)
                    throw new AppException("Email existente", StatusCodes.Status400BadRequest);

                await ClientsRepository.Insert(data);

                return await ClientsRepository.FindByEmail(data.Email);
            }
            catch (AppException ex)
            {
                _logger.LogError("");
                throw new AppException(ex.Message, ex.StatusCode);
            }
        }
    }
}
