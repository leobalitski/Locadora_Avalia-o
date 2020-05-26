using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraMVC.Migrations
{
    public partial class RelacaoBd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Clientes_ClienteIdCliente",
                table: "Locacoes");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteIdCliente",
                table: "Locacoes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Locacoes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Clientes_ClienteIdCliente",
                table: "Locacoes",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Clientes_ClienteIdCliente",
                table: "Locacoes");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Locacoes");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteIdCliente",
                table: "Locacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Clientes_ClienteIdCliente",
                table: "Locacoes",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
