using App.Src.Modules.Customers.Domain.Dtos;
using App.Src.Modules.Customers.Domain.Models;
using System.Threading.Tasks;

namespace App.Src.Modules.CustomerOutDated.Domain.Interfaces.Repositories
{
    public interface IClientsRepository
    {
        public Task Insert(InsertClientDto data);
        public Task<Clients> FindByClientId(int clientId);
        public Task<Clients> FindByEmail(string email);
        public Task Update(UpdateClientDto data);
        public Task Delete(int clientId);

    }
}
