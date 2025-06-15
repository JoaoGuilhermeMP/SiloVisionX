using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiloVisionX.Infra.Migrations
{
    /// <inheritdoc />
    public partial class MudancasNosNomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Silo");

            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.RenameTable(
                name: "Usuários",
                newName: "Usuários",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "Umidade",
                newName: "Umidade",
                newSchema: "Silo");

            migrationBuilder.RenameTable(
                name: "Token",
                newName: "Token",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "Temperatura",
                newName: "Temperatura",
                newSchema: "Silo");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "Auth");

            migrationBuilder.RenameTable(
                name: "Peso",
                newName: "Peso",
                newSchema: "Silo");

            migrationBuilder.RenameTable(
                name: "Geral",
                newName: "Geral",
                newSchema: "Silo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Usuários",
                schema: "Auth",
                newName: "Usuários");

            migrationBuilder.RenameTable(
                name: "Umidade",
                schema: "Silo",
                newName: "Umidade");

            migrationBuilder.RenameTable(
                name: "Token",
                schema: "Auth",
                newName: "Token");

            migrationBuilder.RenameTable(
                name: "Temperatura",
                schema: "Silo",
                newName: "Temperatura");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "Auth",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Peso",
                schema: "Silo",
                newName: "Peso");

            migrationBuilder.RenameTable(
                name: "Geral",
                schema: "Silo",
                newName: "Geral");
        }
    }
}
