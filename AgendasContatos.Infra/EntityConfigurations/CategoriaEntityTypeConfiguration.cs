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
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(p => p.Sigla)
                .IsUnicode(false)
                .HasMaxLength(5);

            builder
                .HasMany(ct => ct.Contatos)
                .WithOne(ca => ca.Categoria);

            builder.HasData(new Categoria
            {
                Id = 1,
                Descricao = "Família",
                Sigla = "FAM"
            },
            new Categoria
            {
                Id = 2,
                Descricao = "Trabalho",
                Sigla = "TRA"
            });
        }
    }
}
