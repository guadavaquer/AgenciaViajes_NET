using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgenciaDeViajes.Migrations
{
    /// <inheritdoc />
    public partial class Nuevosvuelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vuelos",
                columns: new[] { "idVuelo", "aerolinea", "avion", "capacidad", "costo", "fecha", "idCiudadDestino", "idCiudadOrigen" },
                values: new object[,]
                {
                    { 3, "Aero", "LF-5958", 1, 950000.0, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 4, "Aero", "LF-5965", 1, 900000.0, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 5, "Aero", "LF-9531", 1, 850000.0, new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vuelos",
                keyColumn: "idVuelo",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vuelos",
                keyColumn: "idVuelo",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vuelos",
                keyColumn: "idVuelo",
                keyValue: 5);
        }
    }
}
