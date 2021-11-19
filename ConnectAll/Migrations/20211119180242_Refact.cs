using Microsoft.EntityFrameworkCore.Migrations;

namespace ConnectAll.Migrations
{
    public partial class Refact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_produto_tb_ponto_distribuicao_PontoDeDistribuicaoId",
                table: "tb_produto");

            migrationBuilder.AlterColumn<int>(
                name: "PontoDeDistribuicaoId",
                table: "tb_produto",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produto_tb_ponto_distribuicao_PontoDeDistribuicaoId",
                table: "tb_produto",
                column: "PontoDeDistribuicaoId",
                principalTable: "tb_ponto_distribuicao",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_produto_tb_ponto_distribuicao_PontoDeDistribuicaoId",
                table: "tb_produto");

            migrationBuilder.AlterColumn<int>(
                name: "PontoDeDistribuicaoId",
                table: "tb_produto",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_tb_produto_tb_ponto_distribuicao_PontoDeDistribuicaoId",
                table: "tb_produto",
                column: "PontoDeDistribuicaoId",
                principalTable: "tb_ponto_distribuicao",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
