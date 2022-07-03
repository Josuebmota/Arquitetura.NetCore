using App.Src.Modules.Customers.Domain.Dtos;
using System.Threading.Tasks;

namespace App.Src.Modules.CustomerOutDated.Domain.Interfaces.Services
{
    public interface IUpdateClientService
    {
        public Task Execute(UpdateClientDto data);
    }
}
