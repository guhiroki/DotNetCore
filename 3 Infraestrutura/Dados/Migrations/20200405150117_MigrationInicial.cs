using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class MigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    COD_PRODUTO = table.Column<string>(type: "char(4)", nullable: false),
                    DES_PRODUTO = table.Column<string>(maxLength: 30, nullable: true),
                    STA_STATUS = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.COD_PRODUTO);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO_COSIF",
                columns: table => new
                {
                    COD_PRODUTO = table.Column<string>(type: "char(4)", nullable: false),
                    COD_COSIF = table.Column<string>(type: "char(11)", nullable: false),
                    COD_CLASSIFICACAO = table.Column<string>(type: "char(6)", nullable: true),
                    STA_STATUS = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO_COSIF", x => new { x.COD_PRODUTO, x.COD_COSIF });
                    table.ForeignKey(
                        name: "FK_PRODUTO_COSIF_PRODUTO_COD_PRODUTO",
                        column: x => x.COD_PRODUTO,
                        principalTable: "PRODUTO",
                        principalColumn: "COD_PRODUTO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MOVIMENTO_MANUAL",
                columns: table => new
                {
                    COD_PRODUTO = table.Column<string>(type: "char(4)", nullable: false),
                    COD_COSIF = table.Column<string>(type: "char(11)", nullable: false),
                    DAT_MES = table.Column<decimal>(type: "numeric(2,0)", nullable: false),
                    DAT_ANO = table.Column<decimal>(type: "numeric(4,0)", nullable: false),
                    NUM_LANCAMENTO = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    DES_DESCRICAO = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    DAT_MOVIMENTO = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    COD_USUARIO = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    VAL_VALOR = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    ProdutoCodigoProduto = table.Column<string>(nullable: true),
                    ProdutoCosifCodigoProduto = table.Column<string>(nullable: true),
                    ProdutoCosifCodigoProdutoCosif = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVIMENTO_MANUAL", x => new { x.DAT_MES, x.DAT_ANO, x.NUM_LANCAMENTO, x.COD_PRODUTO, x.COD_COSIF });
                    table.ForeignKey(
                        name: "FK_MOVIMENTO_MANUAL_PRODUTO_ProdutoCodigoProduto",
                        column: x => x.ProdutoCodigoProduto,
                        principalTable: "PRODUTO",
                        principalColumn: "COD_PRODUTO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MOVIMENTO_MANUAL_PRODUTO_COSIF_ProdutoCosifCodigoProduto_ProdutoCosifCodigoProdutoCosif",
                        columns: x => new { x.ProdutoCosifCodigoProduto, x.ProdutoCosifCodigoProdutoCosif },
                        principalTable: "PRODUTO_COSIF",
                        principalColumns: new[] { "COD_PRODUTO", "COD_COSIF" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MOVIMENTO_MANUAL_ProdutoCodigoProduto",
                table: "MOVIMENTO_MANUAL",
                column: "ProdutoCodigoProduto");

            migrationBuilder.CreateIndex(
                name: "IX_MOVIMENTO_MANUAL_ProdutoCosifCodigoProduto_ProdutoCosifCodigoProdutoCosif",
                table: "MOVIMENTO_MANUAL",
                columns: new[] { "ProdutoCosifCodigoProduto", "ProdutoCosifCodigoProdutoCosif" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MOVIMENTO_MANUAL");

            migrationBuilder.DropTable(
                name: "PRODUTO_COSIF");

            migrationBuilder.DropTable(
                name: "PRODUTO");
        }
    }
}
