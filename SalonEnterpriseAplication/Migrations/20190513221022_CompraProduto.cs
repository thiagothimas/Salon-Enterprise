using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SalonEnterpriseAplication.Migrations
{
    public partial class CompraProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_compra_produto",
                columns: table => new
                {
                    CompraId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_compra_produto", x => new { x.CompraId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_tb_compra_produto_tb_compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "tb_compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_compra_produto_tb_produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "tb_produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_compra_produto_ProdutoId",
                table: "tb_compra_produto",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_compra_produto");
        }
    }
}
