using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SiloVisionX.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Silo");

            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.CreateTable(
                name: "Geral",
                schema: "Silo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemperaturaValue = table.Column<float>(type: "real", nullable: false),
                    UmidadeValue = table.Column<float>(type: "real", nullable: false),
                    NivelValue = table.Column<float>(type: "real", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Auth",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Nivel",
                schema: "Silo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NivelValue = table.Column<float>(type: "real", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeralId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nivel_Geral_GeralId",
                        column: x => x.GeralId,
                        principalSchema: "Silo",
                        principalTable: "Geral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temperatura",
                schema: "Silo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemperaturaValue = table.Column<float>(type: "real", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeralId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temperatura_Geral_GeralId",
                        column: x => x.GeralId,
                        principalSchema: "Silo",
                        principalTable: "Geral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Umidade",
                schema: "Silo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UmidadeValue = table.Column<float>(type: "real", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeralId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Umidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Umidade_Geral_GeralId",
                        column: x => x.GeralId,
                        principalSchema: "Silo",
                        principalTable: "Geral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuários",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuários", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuários_Roles_Role",
                        column: x => x.Role,
                        principalSchema: "Auth",
                        principalTable: "Roles",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Token_Usuários_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "Usuários",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Roles",
                columns: new[] { "Name", "Description" },
                values: new object[,]
                {
                    { "ADMIN", "Administrador" },
                    { "USER", "Usuário" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nivel_GeralId",
                schema: "Silo",
                table: "Nivel",
                column: "GeralId");

            migrationBuilder.CreateIndex(
                name: "IX_Temperatura_GeralId",
                schema: "Silo",
                table: "Temperatura",
                column: "GeralId");

            migrationBuilder.CreateIndex(
                name: "IX_Token_UserId",
                schema: "Auth",
                table: "Token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Umidade_GeralId",
                schema: "Silo",
                table: "Umidade",
                column: "GeralId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuários_Role",
                schema: "Auth",
                table: "Usuários",
                column: "Role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nivel",
                schema: "Silo");

            migrationBuilder.DropTable(
                name: "Temperatura",
                schema: "Silo");

            migrationBuilder.DropTable(
                name: "Token",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "Umidade",
                schema: "Silo");

            migrationBuilder.DropTable(
                name: "Usuários",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "Geral",
                schema: "Silo");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Auth");
        }
    }
}
