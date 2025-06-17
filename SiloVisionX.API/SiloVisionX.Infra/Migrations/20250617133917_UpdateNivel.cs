using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiloVisionX.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNivel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peso",
                schema: "Silo");

            migrationBuilder.CreateTable(
                name: "Nivel",
                schema: "Silo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NivelValue = table.Column<float>(type: "real", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Nivel_GeralId",
                schema: "Silo",
                table: "Nivel",
                column: "GeralId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nivel",
                schema: "Silo");

            migrationBuilder.CreateTable(
                name: "Peso",
                schema: "Silo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeralId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PesoValue = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peso_Geral_GeralId",
                        column: x => x.GeralId,
                        principalSchema: "Silo",
                        principalTable: "Geral",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peso_GeralId",
                schema: "Silo",
                table: "Peso",
                column: "GeralId");
        }
    }
}
