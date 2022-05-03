﻿// <auto-generated />
using System;
using AgendasContatos.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendasContatos.Infra.Migrations
{
    [DbContext(typeof(ContatosDbContext))]
    [Migration("20220503121931_Initial-create-database")]
    partial class Initialcreatedatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AgendaContatos.Infra.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("AgendaContatos.Infra.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Celular")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NumeroCasa")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Contatos", (string)null);
                });

            modelBuilder.Entity("AgendaContatos.Infra.Models.Contato", b =>
                {
                    b.HasOne("AgendaContatos.Infra.Models.Categoria", "Categoria")
                        .WithMany("Contatos")
                        .HasForeignKey("IdCategoria");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("AgendaContatos.Infra.Models.Categoria", b =>
                {
                    b.Navigation("Contatos");
                });
#pragma warning restore 612, 618
        }
    }
}
