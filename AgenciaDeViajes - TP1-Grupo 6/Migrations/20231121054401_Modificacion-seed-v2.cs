using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaDeViajes.Migrations
{
    /// <inheritdoc />
    public partial class Modificacionseedv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "idVuelo",
                keyValue: 1,
                column: "fecha",
                value: new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "idVuelo",
                keyValue: 2,
                column: "fecha",
                value: new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "idVuelo",
                keyValue: 1,
                column: "fecha",
                value: null);

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "idVuelo",
                keyValue: 2,
                column: "fecha",
                value: null);
        }
    }
}
