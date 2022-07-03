using System.ComponentModel.DataAnnotations;


namespace App.Src.Modules.Customers.Application.Http.Request
{
    public class ClientsRequest
    {
        public class Post
        {
            public class Body
            {
                /// <summary>
                /// Nome do cliente
                /// </summary>
                [Required]
                public string Nome { get; set; }
                /// <summary>
                /// Email do cliente
                /// </summary>
                [Required]
                public string Email { get; set; }

            }
        }
        public class Show
        {
            public class Params
            {
                /// <summary>
                /// Id do cliente
                /// </summary>
                [Required]
                public int ClientId { get; set; }
            }
        }
        public class Update
        {
            public class Params
            {
                /// <summary>
                /// Id do cliente
                /// </summary>
                [Required]
                public int ClientId { get; set; }
            }
            public class Body
            {
                /// <summary>
                /// Nome do cliente
                /// </summary>
                [Required]
                public string Nome { get; set; }
                /// <summary>
                /// Email do cliente
                /// </summary>
                [Required]
                public string Email { get; set; }
            }
        }
        public class Delete
        {
            public class Params
            {
                /// <summary>
                /// Id do cliente
                /// </summary>
                [Required]
                public int ClientId { get; set; }
            }
        }
    }
}
