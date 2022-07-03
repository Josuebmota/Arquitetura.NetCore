namespace App.Src.Shared.Infra.Data.Connection.Interface
{
    public interface IConnectionsDb
    {
        public IConnectionFactory ConnectionOne { get; set; }
    }
}
