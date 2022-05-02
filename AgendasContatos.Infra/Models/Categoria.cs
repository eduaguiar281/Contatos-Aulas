using System.Collections.ObjectModel;

namespace AgendaContatos.Infra.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public virtual ICollection<Contato> Contatos { get; set; } = new Collection<Contato>();
    }
}
