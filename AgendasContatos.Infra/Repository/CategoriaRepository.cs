using AgendaContatos.Infra.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendasContatos.Infra.Repository
{
    public class CategoriaRepository : IRepository<Categoria, int>
    {
        private readonly ContatosDbContext _contatosDbContext;
        public CategoriaRepository(ContatosDbContext contatosDbContext)
        {
            _contatosDbContext = contatosDbContext;
        }

        public async Task DeleteAsync(Categoria data)
        {
            _contatosDbContext.Remove(data);
            await _contatosDbContext.SaveChangesAsync();
        }

        public async Task InsertAsync(Categoria data)
        {
            _contatosDbContext.Add(data);
            await _contatosDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categoria>> ObterAsync(string filtro)
        {
            _ = int.TryParse(filtro, out int id);
            return await _contatosDbContext.Categorias
                .Where(w => w.Id == id || w.Descricao.Contains(filtro))
                .ToListAsync();
        }

        public async Task<Categoria?> ObterPorIdAsync(int id) => await _contatosDbContext.Categorias
                .FirstOrDefaultAsync(w => w.Id == id);

        public async Task<IEnumerable<Categoria>> ObterTodosAsync()
            => await _contatosDbContext.Categorias.ToListAsync();

        public async Task UpdateAsync(Categoria data)
        {
            _contatosDbContext.Update(data);
            await _contatosDbContext.SaveChangesAsync();
        }
    }
}
