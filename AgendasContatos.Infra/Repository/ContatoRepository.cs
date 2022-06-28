using AgendaContatos.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendasContatos.Infra.Repository
{
    public class ContatoRepository : IRepository<Contato, int>
    {

        private readonly ContatosDbContext _contatosDbContext;
        public ContatoRepository(ContatosDbContext contatosDbContext)
        {
            _contatosDbContext = contatosDbContext;
        }

        public async Task DeleteAsync(Contato data)
        {
            _contatosDbContext.Remove(data);
            await _contatosDbContext.SaveChangesAsync();
        }

        public async Task InsertAsync(Contato data)
        {
            _contatosDbContext.Add(data);
            await _contatosDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contato>> ObterAsync(string filtro)
        {
            _ = int.TryParse(filtro, out int id);
            return await _contatosDbContext.Contatos
                .Include(i => i.Categoria)
                .Where(w => w.Id == id || w.Nome.Contains(filtro) || w.Celular.Contains(filtro) ||
                            w.Endereco.Contains(filtro) || w.NumeroCasa.Contains(filtro) || w.Email.Contains(filtro) ||
                            w.Categoria.Descricao.Contains(filtro))
                .ToListAsync();
        }

        public async Task<Contato> ObterPorIdAsync(int id) => await _contatosDbContext.Contatos
                .FirstOrDefaultAsync(w => w.Id == id);

        public async Task<IEnumerable<Contato>> ObterTodosAsync()
            => await _contatosDbContext.Contatos.ToListAsync();

        public async Task UpdateAsync(Contato data)
        {
            _contatosDbContext.Update(data);
            await _contatosDbContext.SaveChangesAsync();
        }
    }
}
