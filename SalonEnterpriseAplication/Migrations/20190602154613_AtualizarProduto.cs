using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SalonEnterpriseAplication.Migrations
{
    public partial class AtualizarProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<double>(
                name: "ValorTotal",
                table: "tb_produtos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "tb_produtos");

            
        }
    }
}
