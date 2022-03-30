using AgendaContatos.Contatos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaContatos.Core.Infraestrutura
{
    public interface IContatosDatabase
    {
        List<Contato> ObterLista();
        List<Contato> ObterLista(string filtro);
        Task InsertContato(Contato contato);
        Task UpdateContato(Contato contato);
        Task DeleteContato(int idContato);
    }
}
