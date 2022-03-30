using AgendaContatos.Core;
using AgendaContatos.Core.Infraestrutura;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.Categorias.Models
{
    public class CategoriasDatabase : ICategoriasDatabase
    {
        private const string SELECT_CATEGORIA = "Select Id, Descricao From Categorias";
        private const string INSERT_CATEGORIA = "Insert into Categorias (Descricao) values (@Descricao); SELECT CAST(SCOPE_IDENTITY() as int);";
        private const string UPDATE_CATEGORIA = "Update Categorias SET Descricao = @Descricao Where Id = @Id";
        private const string DELETE_CATEGORIA = "Delete From Categorias Where Id = @Id";

        private readonly IConnectionFactory _connectionFactory;
        public CategoriasDatabase(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Categoria> ObterLista()
        {
            using IDbConnection connection = _connectionFactory.ObterConexao();
            return connection.Query<Categoria>(SELECT_CATEGORIA).ToList();
        }

        public List<Categoria> ObterLista(string filtro)
        {
            string sql = SELECT_CATEGORIA + " Where Id = @id or Descricao like @descricao";
            int.TryParse(filtro, out int id);
            using IDbConnection connection = _connectionFactory.ObterConexao();
            return connection.Query<Categoria>(sql, new { id, descricao = $"%{filtro}%" }).ToList();
        }

        public async Task InsertCategoria(Categoria categoria)
        {
            using IDbConnection connection = _connectionFactory.ObterConexao();
            int id =  await connection.ExecuteScalarAsync<int>(INSERT_CATEGORIA, categoria);
            categoria.Id = id;
        }
        public async Task UpdateCategoria(Categoria categoria)
        {
            using IDbConnection connection = _connectionFactory.ObterConexao();
            await connection.ExecuteAsync(UPDATE_CATEGORIA, categoria);
        }
        public async Task DeleteCategoria(int idCategoria)
        {
            using IDbConnection connection = _connectionFactory.ObterConexao();
            await connection.ExecuteAsync(DELETE_CATEGORIA, new { Id = idCategoria });
        }
    }
}
