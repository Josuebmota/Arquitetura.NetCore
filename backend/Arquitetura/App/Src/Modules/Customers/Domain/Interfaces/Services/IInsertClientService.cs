using App.Src.Modules.Customers.Domain.Dtos;
using App.Src.Modules.Customers.Domain.Models;
using System.Threading.Tasks;

namespace App.Src.Modules.CustomerOutDated.Domain.Interfaces.Services
{
    public interface IInsertClientService
    {
        public Task<Clients> Execute(InsertClientDto data);
    }
}
