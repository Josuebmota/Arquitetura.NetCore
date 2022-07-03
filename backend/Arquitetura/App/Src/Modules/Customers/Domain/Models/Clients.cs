using System;

namespace App.Src.Modules.Customers.Domain.Models
{
    public class Clients
    {
        public int ClientId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
