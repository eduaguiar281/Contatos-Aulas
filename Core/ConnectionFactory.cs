using System.Data.SqlClient;

namespace AgendaContatos.Core
{
    public static class ConnectionFactory
    {
        public const string ConnectionString = "Server=localhost, 2433; Database=ContatosDb; User ID=sa; Password=A123456@;";
        public static SqlConnection ObterConexao()
        {
            SqlConnection conexao = new (ConnectionString);
            conexao.Open();
            return conexao;
        }
    }
}
