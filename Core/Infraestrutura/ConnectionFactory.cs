using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AgendaContatos.Core.Infraestrutura
{
    public class ConnectionFactory : IConnectionFactory
    {
        public ConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer");
        }
        private readonly string _connectionString;
        public string ConnectionString { get { return _connectionString; } }

        public IDbConnection ObterConexao()
        {
            SqlConnection conexao = new (ConnectionString);
            conexao.Open();
            return conexao;
        }
    }
}
