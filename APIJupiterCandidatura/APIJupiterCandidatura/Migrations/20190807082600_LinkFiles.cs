using Microsoft.EntityFrameworkCore.Migrations;

namespace APIJupiterCandidatura.Migrations
{
    public partial class LinkFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem",
                table: "Vagas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FicheiroCurriculo",
                table: "Candidatos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem",
                table: "Vagas");

            migrationBuilder.DropColumn(
                name: "FicheiroCurriculo",
                table: "Candidatos");
        }
    }
}
