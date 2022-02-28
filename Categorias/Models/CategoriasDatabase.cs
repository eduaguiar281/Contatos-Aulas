using AgendaContatos.Core;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.Categorias.Models
{
    public static class CategoriasDatabase 
    {
        private const string SELECT_CATEGORIA = "Select Id, Descricao From Categorias";
        private const string INSERT_CATEGORIA = "Insert into Categorias (Descricao) values (@Descricao); SELECT CAST(SCOPE_IDENTITY() as int);";
        private const string UPDATE_CATEGORIA = "Update Categorias SET Descricao = @Descricao Where Id = @Id";
        private const string DELETE_CATEGORIA = "Delete From Categorias Where Id = @Id";


        public static List<Categoria> ObterLista()
        {
            using SqlConnection connection = ConnectionFactory.ObterConexao();
            return connection.Query<Categoria>(SELECT_CATEGORIA).ToList();
        }

        public static List<Categoria> ObterLista(string filtro)
        {
            string sql = SELECT_CATEGORIA + " Where Id = @id or Descricao like @descricao";
            int.TryParse(filtro, out int id);
            using SqlConnection connection = ConnectionFactory.ObterConexao();
            return connection.Query<Categoria>(sql, new { id, descricao = $"%{filtro}%" }).ToList();
        }

        public static async Task InsertCategoria(Categoria categoria)
        {
            using SqlConnection connection = ConnectionFactory.ObterConexao();
            int id =  await connection.ExecuteScalarAsync<int>(INSERT_CATEGORIA, categoria);
            categoria.Id = id;
        }
        public static async Task UpdateCategoria(Categoria categoria)
        {
            using SqlConnection connection = ConnectionFactory.ObterConexao();
            await connection.ExecuteAsync(UPDATE_CATEGORIA, categoria);
        }
        public static async Task DeleteCategoria(int idCategoria)
        {
            using SqlConnection connection = ConnectionFactory.ObterConexao();
            await connection.ExecuteAsync(DELETE_CATEGORIA, new { Id = idCategoria });
        }
    }
}
