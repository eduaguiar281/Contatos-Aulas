using AgendaContatos.Infra.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaContatos.Core.Infraestrutura
{
    public interface ICategoriasDatabase
    {
        List<Categoria> ObterLista();
        List<Categoria> ObterLista(string filtro);
        Task InsertCategoria(Categoria categoria);
        Task UpdateCategoria(Categoria categoria);
        Task DeleteCategoria(int idCategoria);

    }
}
