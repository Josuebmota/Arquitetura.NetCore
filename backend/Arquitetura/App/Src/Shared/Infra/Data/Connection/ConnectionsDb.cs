using App.Src.Shared.Infra.Data.Connection.Interface;

namespace App.Src.Shared.Infra.Data.Connection
{
    public class ConnectionsDb : IConnectionsDb
    {
        public IConnectionFactory ConnectionOne { get; set; }
    }
}
