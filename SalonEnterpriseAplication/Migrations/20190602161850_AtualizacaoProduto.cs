using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SalonEnterpriseAplication.Migrations
{
    public partial class AtualizacaoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "tb_compras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tb_compras_ProdutoId",
                table: "tb_compras",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_compras_tb_produtos_ProdutoId",
                table: "tb_compras",
                column: "ProdutoId",
                principalTable: "tb_produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropForeignKey(
                name: "FK_tb_compras_tb_produtos_ProdutoId",
                table: "tb_compras");

            migrationBuilder.DropIndex(
                name: "IX_tb_compras_ProdutoId",
                table: "tb_compras");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "tb_compras");

            
        }
    }
}
