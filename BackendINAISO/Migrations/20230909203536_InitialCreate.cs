﻿using System;
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
                    { 1, new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5803), new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5848), "Usuario1" },
                    { 2, new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5850), new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5851), "Usuario2" },
                    { 3, new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5853), new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5854), "Usuario3" },
                    { 4, new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5856), new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5857), "Usuario4" },
                    { 5, new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5859), new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5860), "Usuario5" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "AplicacionId", "FechaFin", "FechaInicio", "UsuarioId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 9, 12, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5984), new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5982), 1 },
                    { 2, 1, new DateTime(2023, 9, 13, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5989), new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5988), 2 },
                    { 3, 2, new DateTime(2023, 9, 14, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5992), new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5991), 3 },
                    { 4, 2, new DateTime(2023, 9, 15, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5995), new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5994), 4 },
                    { 5, 3, new DateTime(2023, 9, 16, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5997), new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5996), 1 },
                    { 6, 3, new DateTime(2023, 9, 17, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(6000), new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(5999), 2 },
                    { 7, 1, new DateTime(2023, 9, 18, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(6003), new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(6002), 3 },
                    { 8, 1, new DateTime(2023, 9, 19, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(6005), new DateTime(2023, 9, 9, 17, 35, 36, 634, DateTimeKind.Local).AddTicks(6004), 4 }
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
