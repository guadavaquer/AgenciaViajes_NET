using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaDeViajes.Migrations
{
    /// <inheritdoc />
    public partial class Modificacionseedv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hoteles",
                keyColumn: "idHotel",
                keyValue: 1,
                column: "idCiudad",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Hoteles",
                keyColumn: "idHotel",
                keyValue: 2,
                column: "idCiudad",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "idVuelo",
                keyValue: 1,
                columns: new[] { "idCiudadDestino", "idCiudadOrigen" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "idVuelo",
                keyValue: 2,
                columns: new[] { "idCiudadDestino", "idCiudadOrigen" },
                values: new object[] { 1, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hoteles",
                keyColumn: "idHotel",
                keyValue: 1,
                column: "idCiudad",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hoteles",
                keyColumn: "idHotel",
                keyValue: 2,
                column: "idCiudad",
                value: null);

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "idVuelo",
                keyValue: 1,
                columns: new[] { "idCiudadDestino", "idCiudadOrigen" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Vuelos",
                keyColumn: "idVuelo",
                keyValue: 2,
                columns: new[] { "idCiudadDestino", "idCiudadOrigen" },
                values: new object[] { null, null });
        }
    }
}
