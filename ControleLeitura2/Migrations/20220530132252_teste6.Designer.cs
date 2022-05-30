﻿// <auto-generated />
using System;
using ControleLeitura2.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleLeitura2.Migrations
{
    [DbContext(typeof(ControleLeituraContext))]
    [Migration("20220530132252_teste6")]
    partial class teste6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ControleLeitura2.Models.Autor", b =>
                {
                    b.Property<int>("AutorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AutorId"), 1L, 1);

                    b.Property<string>("AutorNacionalidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AutorNome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AutorId");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("ControleLeitura2.Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"), 1L, 1);

                    b.Property<string>("CategoriaNome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ControleLeitura2.Models.Editora", b =>
                {
                    b.Property<int>("EditoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EditoraId"), 1L, 1);

                    b.Property<string>("EditoraCnpj")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("EditoraEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EditoraNome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TelefoneEditora")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("EditoraId");

                    b.ToTable("Editoras");
                });

            modelBuilder.Entity("ControleLeitura2.Models.Livro", b =>
                {
                    b.Property<int>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LivroId"), 1L, 1);

                    b.Property<int>("AnoLancamento")
                        .HasColumnType("int");

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<int>("EditoraId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavorito")
                        .HasColumnType("bit");

                    b.Property<string>("LivroCapaCaminho")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NomeLivro")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double?>("Nota")
                        .HasColumnType("float");

                    b.Property<int?>("PaginaAtual")
                        .HasColumnType("int");

                    b.Property<int>("PrioridadeId")
                        .HasColumnType("int");

                    b.Property<string>("ResumoLivro")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("LivroId");

                    b.HasIndex("AutorId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EditoraId");

                    b.HasIndex("PrioridadeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("ControleLeitura2.Models.Prioridade", b =>
                {
                    b.Property<int>("PrioridadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrioridadeId"), 1L, 1);

                    b.Property<string>("PrioridadeNome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PrioridadeId");

                    b.ToTable("Prioridade");
                });

            modelBuilder.Entity("ControleLeitura2.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"), 1L, 1);

                    b.Property<string>("NomeStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StatusId");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("ControleLeitura2.Models.Livro", b =>
                {
                    b.HasOne("ControleLeitura2.Models.Autor", "Autor")
                        .WithMany("Livros")
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleLeitura2.Models.Categoria", "Categoria")
                        .WithMany("Livros")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleLeitura2.Models.Editora", "Editora")
                        .WithMany("Livros")
                        .HasForeignKey("EditoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleLeitura2.Models.Prioridade", "Prioridade")
                        .WithMany("Livros")
                        .HasForeignKey("PrioridadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleLeitura2.Models.Status", "Status")
                        .WithMany("Livros")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Categoria");

                    b.Navigation("Editora");

                    b.Navigation("Prioridade");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ControleLeitura2.Models.Autor", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("ControleLeitura2.Models.Categoria", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("ControleLeitura2.Models.Editora", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("ControleLeitura2.Models.Prioridade", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("ControleLeitura2.Models.Status", b =>
                {
                    b.Navigation("Livros");
                });
#pragma warning restore 612, 618
        }
    }
}
