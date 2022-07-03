namespace App.Src.Modules.Customers.Domain.Dtos
{
    public class UpdateClientDto : InsertClientDto
    {
        public int ClientId { get; set; }

        public UpdateClientDto(int clientId,string nome, string email) 
            : base(nome, email)
        {
            ClientId = clientId;
        }
    }
}
