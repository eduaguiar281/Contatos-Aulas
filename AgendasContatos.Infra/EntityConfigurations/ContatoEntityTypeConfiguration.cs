using AgendaContatos.Infra.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendasContatos.Infra.EntityConfigurations
{
    internal class ContatoEntityTypeConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable($"{nameof(Contato)}s");
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Celular)
                .IsUnicode(false)
                .HasMaxLength(20);

            builder.Property(p => p.Telefone)
                .IsUnicode(false)
                .HasMaxLength(20)
                .IsRequired();
            
            builder.Property(p => p.Nome)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();


            builder.Property(p => p.Endereco)
                .IsUnicode(false)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.NumeroCasa)
                .IsUnicode(false)
                .HasMaxLength(20);

            builder.Property(p => p.Email)
                .IsUnicode(false)
                .HasMaxLength(60);

            builder.Ignore(p => p.DescricaoCategoria);
            //Pode ser colocado o atributo [NotMapped] na classe


            builder.Property(p => p.DataCadastro);

            /*Repare que os campos Ativo, IdCategoria eu não farei o mapeamento e o entity fará isso automático
             1 - O ativo vai ser mapeado como bit not null
             2 - IdCategoria está sendo mateado na classe CategoriaEntityTypeConfiguration 


            Documentação:
            https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/relationships
            https://docs.microsoft.com/pt-br/ef/core/managing-schemas/migrations/applying?tabs=vs
            https://stackoverflow.com/questions/51982019/exclude-properties-for-migrations
             */
        }
    }
}
