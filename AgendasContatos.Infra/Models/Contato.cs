using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaContatos.Infra.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string? Celular { get; set; }
        public string? Telefone { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string? NumeroCasa { get; set; }
        public string? Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        //public int? IdCategoria { get; set; }
        public string? DescricaoCategoria { get { return Categoria?.Descricao; } }
        public virtual Categoria? Categoria { get; set; }
    }
}
