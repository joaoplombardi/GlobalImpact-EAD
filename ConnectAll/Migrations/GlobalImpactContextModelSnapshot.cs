﻿// <auto-generated />
using System;
using ConnectAll.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConnectAll.Migrations
{
    [DbContext(typeof(GlobalImpactContext))]
    partial class GlobalImpactContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GlobalImpact.Models.Parceiro", b =>
                {
                    b.Property<int>("ParceiroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cpf_cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParceiroId");

                    b.ToTable("tb_parceiro");
                });

            modelBuilder.Entity("GlobalImpact.Models.PontoDeDistribuicao", b =>
                {
                    b.Property<int>("PontoDeDistribuicaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PontoDeDistribuicaoId");

                    b.ToTable("tb_ponto_distribuicao");
                });

            modelBuilder.Entity("GlobalImpact.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataValidade")
                        .HasColumnName("dt_validade")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DistribuidorId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PontoDeDistribuicaoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.HasIndex("DistribuidorId");

                    b.HasIndex("PontoDeDistribuicaoId");

                    b.ToTable("tb_produto");
                });

            modelBuilder.Entity("GlobalImpact.Models.Produto", b =>
                {
                    b.HasOne("GlobalImpact.Models.Parceiro", "Distribuidor")
                        .WithMany("ProdutosDistribuidos")
                        .HasForeignKey("DistribuidorId");

                    b.HasOne("GlobalImpact.Models.PontoDeDistribuicao", "PontoDeDistribuicao")
                        .WithMany("Estoque")
                        .HasForeignKey("PontoDeDistribuicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}