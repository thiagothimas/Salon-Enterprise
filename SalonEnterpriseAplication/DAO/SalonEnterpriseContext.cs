using Microsoft.EntityFrameworkCore;
using SalonEnterpriseAplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalonEnterpriseAplication.DAO
{
    public class SalonEnterpriseContext : DbContext
    {
        public DbSet<Cliente> tb_clientes { get; set; }
        public DbSet<Fornecedor> tb_fornecedores { get; set; }
        public DbSet<Funcionario> tb_funcionarios { get; set; }
        public DbSet<Produto> tb_produtos { get; set; }
        public DbSet<Servico> tb_servicos { get; set; }
        public DbSet<Compra> tb_compras { get; set; }
        public DbSet<OrdemServico> tb_ordem_servico { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            //modelBuilder
            //   .Entity<ClienteServico>()
            //   .HasKey(cs => new { cs.ClienteId, cs.ServicosRealizadosId });

            //modelBuilder
            //    .Entity<VendaProduto>()
            //    .HasKey(vp => new { vp.ServicoVendaId, vp.ProdutoId });

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=salonenterprise.database.windows.net;Initial Catalog=Radice;User ID=MichaelDataBase;Password=Maico-5991;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

    }
}