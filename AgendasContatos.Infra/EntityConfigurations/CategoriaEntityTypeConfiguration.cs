using AgendaContatos.Infra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendasContatos.Infra.EntityConfigurations
{
    internal class CategoriaEntityTypeConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable($"{nameof(Categoria)}s");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Descricao)
            .HasColumnName("Descricao") //Observação: Não é necessário estou apenas ilustrando que posso mapear o nome da coluna 
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.HasMany(c => c.Contatos)
               .WithOne()
               .HasForeignKey("IdCategoria")
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
