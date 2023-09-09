using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendINAISO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Clase = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    AplicacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Aplicaciones_AplicacionId",
                        column: x => x.AplicacionId,
                        principalTable: "Aplicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Aplicaciones",
                columns: new[] { "Id", "Clase" },
                values: new object[,]
                {
                    { 1, "a" },
                    { 2, "b" },
                    { 3, "c" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1000), new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1051), "Usuario1" },
                    { 2, new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1053), new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1054), "Usuario2" },
                    { 3, new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1056), new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1057), "Usuario3" },
                    { 4, new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1059), new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1060), "Usuario4" },
                    { 5, new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1061), new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1062), "Usuario5" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "AplicacionId", "FechaFin", "FechaInicio", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 12, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1176), new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1175), 1 },
                    { 2, 1, new DateTime(2023, 9, 13, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1182), new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1180), 2 },
                    { 3, 2, new DateTime(2023, 9, 14, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1184), new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1183), 3 },
                    { 4, 2, new DateTime(2023, 9, 15, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1187), new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1186), 4 },
                    { 5, 3, new DateTime(2023, 9, 16, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1190), new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1189), 1 },
                    { 6, 3, new DateTime(2023, 9, 17, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1193), new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1191), 2 },
                    { 7, 1, new DateTime(2023, 9, 18, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1195), new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1194), 3 },
                    { 8, 1, new DateTime(2023, 9, 19, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1198), new DateTime(2023, 9, 9, 17, 18, 43, 620, DateTimeKind.Local).AddTicks(1197), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AplicacionId",
                table: "Reservas",
                column: "AplicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_UsuarioId",
                table: "Reservas",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Aplicaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
