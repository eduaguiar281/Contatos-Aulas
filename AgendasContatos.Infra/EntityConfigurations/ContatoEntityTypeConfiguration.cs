﻿using AgendaContatos.Infra.Models;
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
            .HasColumnType("varchar(20)");

            builder.Property(p => p.Telefone)
            .HasColumnType("varchar(20)")
            .IsRequired();
            
            builder.Property(p => p.Nome)
            .HasColumnType("varchar(50)")
            .IsRequired();


            builder.Property(p => p.Endereco)
            .HasColumnType("varchar(50)")
            .IsRequired();

            builder.Property(p => p.NumeroCasa)
            .HasColumnType("varchar(20)");

            builder.Property(p => p.Email)
            .HasColumnType("varchar(60)")
            .IsRequired();

            builder.Property(p => p.DataCadastro)
            .HasColumnType("datetime2"); //Não é necessário este mapeamento, está aqui apenas para informar isso

            /*Repare que os campos Ativo, IdCategoria eu não farei o mapeamento e o entity fará isso automático
             1 - O ativo vai ser mapeado como bit not null
             2 - IdCategoria está sendo mateado na classe CategoriaEntityTypeConfiguration 
             */
        }
    }
}