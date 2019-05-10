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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("user id=sa;password=maico5991;data source=WIN-97UBVF8RAX\\SQLEXPRESS;Initial Catalog=Radice");
        }

    }
}