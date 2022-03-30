using System.Data;

namespace AgendaContatos.Core.Infraestrutura
{
    public interface IConnectionFactory
    {
        string ConnectionString { get; }
        IDbConnection ObterConexao();
    }
}
