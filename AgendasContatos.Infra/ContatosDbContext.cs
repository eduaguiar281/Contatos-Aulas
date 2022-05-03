using AgendaContatos.Infra.Models;
using AgendasContatos.Infra.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace AgendasContatos.Infra
{
    public class ContatosDbContext :DbContext
    {
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Contato>? Contatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost, 2433; Database=ContatosDb; User ID=sa; Password=A123456@;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContatoEntityTypeConfiguration());
        }

    }
}
