﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrcamentoEletricoInfra.Database;

#nullable disable

namespace OrcamentoEletricoInfra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("OrcamentoEletricoDomain.Entities.Imovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Classificacao")
                        .HasColumnType("int");

                    b.Property<int>("MetrosQuadrados")
                        .HasColumnType("int");

                    b.Property<int>("NumeroDePavimentos")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Projetos", (string)null);
                });

            modelBuilder.Entity("OrcamentoEletricoDomain.Entities.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Endereco")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("OrcamentoEletricoDomain.Entities.Imovel", b =>
                {
                    b.HasOne("OrcamentoEletricoDomain.Entities.Pessoa", "Pessoa")
                        .WithMany("ListaImoveis")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("OrcamentoEletricoDomain.Entities.Pessoa", b =>
                {
                    b.Navigation("ListaImoveis");
                });
#pragma warning restore 612, 618
        }
    }
}