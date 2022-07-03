using System.Data;

namespace App.Src.Shared.Infra.Data.Connection.Interface
{
    public interface IConnectionFactory
    {
        public IDbConnection CreateConnection();
        public IDbConnection CreateConnectionOpened();
    }
}
