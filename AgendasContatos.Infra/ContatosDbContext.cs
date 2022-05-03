using AgendaContatos.Infra.Models;
using AgendasContatos.Infra.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AgendasContatos.Infra
{
    public class ContatosDbContext :DbContext
    {
        public ContatosDbContext(DbContextOptions<ContatosDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContatoEntityTypeConfiguration());
        }

    }
}
