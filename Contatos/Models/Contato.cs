using AgendaContatos.Categorias.Models;
using System;
using System.Collections.Generic;

namespace AgendaContatos.Contatos.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string? Celular { get; set; }
        public string? Telefone { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string NumeroCasa { get; set; } = string.Empty;
        public string? Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public int? IdCategoria { get; set; }
        public string? DescricaoCategoria { get; set; }
    }
}
