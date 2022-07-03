namespace App.Src.Modules.Customers.Domain.Dtos
{
    public class InsertClientDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public InsertClientDto(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
