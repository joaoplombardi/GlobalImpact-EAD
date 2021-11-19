using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConnectAll.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_parceiro",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    cpf_cnpj = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_parceiro", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_ponto_distribuicao",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Endereco = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ponto_distribuicao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_produto",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    dt_validade = table.Column<DateTime>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    DistribuidorId = table.Column<int>(nullable: true),
                    PontoDeDistribuicaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_produto_tb_parceiro_DistribuidorId",
                        column: x => x.DistribuidorId,
                        principalTable: "tb_parceiro",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tb_produto_tb_ponto_distribuicao_PontoDeDistribuicaoId",
                        column: x => x.PontoDeDistribuicaoId,
                        principalTable: "tb_ponto_distribuicao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_DistribuidorId",
                table: "tb_produto",
                column: "DistribuidorId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_produto_PontoDeDistribuicaoId",
                table: "tb_produto",
                column: "PontoDeDistribuicaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_produto");

            migrationBuilder.DropTable(
                name: "tb_parceiro");

            migrationBuilder.DropTable(
                name: "tb_ponto_distribuicao");
        }
    }
}
