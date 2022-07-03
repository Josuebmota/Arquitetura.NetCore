namespace App.Src.Modules.Customers.Infra.Data.Repositories.Dapper.Querys
{
    public static class ClientsQuery
    {
        internal readonly static string Columns = @"C.ID  AS ClientId
                                         , C.NOME     AS Nome
                                         , C.EMAIL     AS Email
                                         , C.DATA_CADASTRO AS DataCadastro";

        internal readonly static string Insert = $@"INSERT INTO CLIENTES (NOME, EMAIL, DATA_CADASTRO)
                                                    VALUES (@Nome, @Email, GETDATE());";

        internal readonly static string FindByClientId = $@"SELECT TOP 1 {Columns}
                                                FROM CLIENTES C WITH(NOLOCK)
                                                WHERE C.ID = @ClientId;";

        internal readonly static string FindByEmail = $@"SELECT TOP 1 {Columns}
                                                FROM CLIENTES C WITH(NOLOCK)
                                                WHERE C.EMAIL = @Email;";

        internal readonly static string Update = $@"UPDATE CLIENTES
                                                SET NOME = @Nome,
                                                    EMAIL = @Email
                                                WHERE ID = @ClientId;";

        internal readonly static string Delete = $@"DELETE CLIENTES WHERE ID = @ClientId;";
    }
}
