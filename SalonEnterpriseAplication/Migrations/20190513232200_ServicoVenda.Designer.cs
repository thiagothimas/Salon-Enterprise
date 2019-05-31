﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SalonEnterpriseAplication.DAO;
using System;

namespace SalonEnterpriseAplication.Migrations
{
    [DbContext(typeof(SalonEnterpriseContext))]
    [Migration("20190513232200_ServicoVenda")]
    partial class ServicoVenda
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SalonEnterpriseAplication.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf")
                        .IsRequired();

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("Endereco")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Rg")
                        .IsRequired();

                    b.Property<string>("Sexo")
                        .IsRequired();

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("tb_clientes");
                });

            modelBuilder.Entity("SalonEnterpriseAplication.Models.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCompra");

                    b.Property<int>("FornecedorId");

                    b.Property<int>("Quantidade");

                    b.Property<double>("ValorTotal");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.ToTable("tb_compras");
                });

            modelBuilder.Entity("SalonEnterpriseAplication.Models.CompraProduto", b =>
                {
                    b.Property<int>("CompraId");

                    b.Property<int>("ProdutoId");

                    b.HasKey("CompraId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("tb_compra_produto");
                });

            modelBuilder.Entity("SalonEnterpriseAplication.Models.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProdutoId");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("tb_estoque");
                });

            modelBuilder.Entity("SalonEnterpriseAplication.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cnpj")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("tb_fornecedores");
                });

            modelBuilder.Entity("SalonEnterpriseAplication.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cargo")
                        .IsRequired();

                    b.Property<string>("ConfirmaSenha")
                        .IsRequired();

                    b.Property<string>("Cpf")
                        .IsRequired();

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("Endereco")
                        .IsRequired();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Rg")
                        .IsRequired();

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.Property<string>("Sexo")
                        .IsRequired();

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("tb_funcionarios");
                });

            modelBuilder.Entity("SalonEnterpriseAplication.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Quantidade");

                    b.Property<string>("Tipo");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.ToTable("tb_produtos");
                });

            modelBuilder.Entity("SalonEnterpriseAplication.Models.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Tipo")
                        .IsRequired();

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.ToTable("tb_servicos");
                });

            modelBuilder.Entity("SalonEnterpriseAplication.Models.Servico_Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("Data");

                    b.Property<int>("Quantidade");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("tb_servico_venda");
                });

            modelBuilder.Entity("SalonEnterpriseAplication.Models.Compra", b =>
                {
                    b.HasOne("SalonEnterpriseAplication.Models.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SalonEnterpriseAplication.Models.CompraProduto", b =>
                {
                    b.HasOne("SalonEnterpriseAplication.Models.Compra", "Compra")
                        .WithMany("Compras")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SalonEnterpriseAplication.Models.Produto", "Produto")
                        .WithMany("Produtos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SalonEnterpriseAplication.Models.Estoque", b =>
                {
                    b.HasOne("SalonEnterpriseAplication.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SalonEnterpriseAplication.Models.Servico_Venda", b =>
                {
                    b.HasOne("SalonEnterpriseAplication.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
