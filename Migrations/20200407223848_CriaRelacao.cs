using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraMVC.Migrations
{
    public partial class CriaRelacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocacaoFilme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdLocacao = table.Column<int>(nullable: false),
                    LocacaoIdLocacao = table.Column<int>(nullable: true),
                    IdFilme = table.Column<int>(nullable: false),
                    FilmeIdFilme = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocacaoFilme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocacaoFilme_Filmes_FilmeIdFilme",
                        column: x => x.FilmeIdFilme,
                        principalTable: "Filmes",
                        principalColumn: "IdFilme",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocacaoFilme_Locacoes_LocacaoIdLocacao",
                        column: x => x.LocacaoIdLocacao,
                        principalTable: "Locacoes",
                        principalColumn: "IdLocacao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoFilme_FilmeIdFilme",
                table: "LocacaoFilme",
                column: "FilmeIdFilme");

            migrationBuilder.CreateIndex(
                name: "IX_LocacaoFilme_LocacaoIdLocacao",
                table: "LocacaoFilme",
                column: "LocacaoIdLocacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocacaoFilme");
        }
    }
}
