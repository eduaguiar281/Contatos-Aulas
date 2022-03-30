using AgendaContatos.Core.Infraestrutura;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaContatos.Contatos.Models
{
    public class ContatosDatabase : IContatosDatabase
    {
        private const string SELECT_CONTATO = @"Select c.Id, c.Celular, c.Telefone, c.Nome,
                                                      c.Endereco, c.NumeroCasa, c.Email, 
	                                                  c.DataCadastro, c.Ativo, c.IdCategoria,
	                                                  cat.Descricao as DescricaoCategoria
                                                 From Contatos c
                                                 Left Join Categorias cat ON c.IdCategoria = cat.Id";

        private const string INSERT_CONTATO = @"Insert into Contatos (Celular, Telefone, Nome, Endereco, NumeroCasa, Email, DataCadastro, Ativo, IdCategoria)
                                                               Values (@Celular, @Telefone, @Nome, @Endereco, @NumeroCasa, @Email, @DataCadastro, @Ativo, @IdCategoria);
                                                SELECT CAST(SCOPE_IDENTITY() as int);";
        private const string UPDATE_CONTATO = @"Update Contatos SET Celular = @Celular, Telefone = @Telefone, Nome = @Nome, Endereco = @Endereco, 
                                                                     NumeroCasa = @NumeroCasa, Email = @Email, DataCadastro = @DataCadastro, 
                                                                     Ativo = @Ativo, IdCategoria = @IdCategoria
                                                  Where Id = @Id";
        private const string DELETE_CONTATO = "Delete From Contatos Where Id = @Id";

        private readonly IConnectionFactory _connectionFactory;
        public ContatosDatabase(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public List<Contato> ObterLista()
        {
            using IDbConnection connection = _connectionFactory.ObterConexao();
            return connection.Query<Contato>(SELECT_CONTATO).ToList();
        }
        public List<Contato> ObterLista(string filtro)
        {
            string sql = SELECT_CONTATO + @" Where c.Id = @id or c.Nome like @filtro or c.Celular like @filtro or c.Telefone like @filtro
                                                or c.Endereco like @filtro or c.NumeroCasa like @filtro or c.Email like @filtro 
                                                or cat.Descricao like @filtro";
            int.TryParse(filtro, out int id);
            using IDbConnection connection = _connectionFactory.ObterConexao();
            return connection.Query<Contato>(sql, new { id, filtro = $"%{filtro}%" }).ToList();
        }

        public async Task InsertContato(Contato contato)
        {
            using IDbConnection connection = _connectionFactory.ObterConexao();
            int id = await connection.ExecuteScalarAsync<int>(INSERT_CONTATO, contato);
            contato.Id = id;
        }
        public async Task UpdateContato(Contato contato)
        {
            using IDbConnection connection = _connectionFactory.ObterConexao();
            await connection.ExecuteAsync(UPDATE_CONTATO, contato);
        }
        public async Task DeleteContato(int idContato)
        {
            using IDbConnection connection = _connectionFactory.ObterConexao();
            await connection.ExecuteAsync(DELETE_CONTATO, new { Id = idContato });
        }

    }
}
