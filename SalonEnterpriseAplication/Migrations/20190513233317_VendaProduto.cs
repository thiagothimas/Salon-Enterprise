using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SalonEnterpriseAplication.Migrations
{
    public partial class VendaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_venda_produtos",
                columns: table => new
                {
                    ServicoVendaId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_venda_produtos", x => new { x.ServicoVendaId, x.ProdutoId });
                    table.ForeignKey(
                        name: "FK_tb_venda_produtos_tb_produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "tb_produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_venda_produtos_tb_servico_venda_ServicoVendaId",
                        column: x => x.ServicoVendaId,
                        principalTable: "tb_servico_venda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_venda_produtos_ProdutoId",
                table: "tb_venda_produtos",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_venda_produtos");
        }
    }
}
