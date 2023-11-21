using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgenciaDeViajes.Migrations
{
    /// <inheritdoc />
    public partial class Relacionespropiedades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuarios",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Usuarios",
                newName: "mail");

            migrationBuilder.RenameColumn(
                name: "IntentosFallidos",
                table: "Usuarios",
                newName: "intentosFallidos");

            migrationBuilder.RenameColumn(
                name: "EsAdmin",
                table: "Usuarios",
                newName: "esAdmin");

            migrationBuilder.RenameColumn(
                name: "DNI",
                table: "Usuarios",
                newName: "dni");

            migrationBuilder.RenameColumn(
                name: "Credito",
                table: "Usuarios",
                newName: "credito");

            migrationBuilder.RenameColumn(
                name: "Bloqueado",
                table: "Usuarios",
                newName: "bloqueado");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Usuarios",
                newName: "apellido");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Usuarios",
                newName: "idUsuario");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Usuarios",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Usuarios",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "mail",
                table: "Usuarios",
                type: "varchar(512)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "intentosFallidos",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "credito",
                table: "Usuarios",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "apellido",
                table: "Usuarios",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    idCiudad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(512)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.idCiudad);
                });

            migrationBuilder.CreateTable(
                name: "Hoteles",
                columns: table => new
                {
                    idHotel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(512)", nullable: false),
                    capacidad = table.Column<int>(type: "int", nullable: false),
                    costo = table.Column<double>(type: "float", nullable: false),
                    idCiudad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteles", x => x.idHotel);
                    table.ForeignKey(
                        name: "FK_Hoteles_Ciudades_idCiudad",
                        column: x => x.idCiudad,
                        principalTable: "Ciudades",
                        principalColumn: "idCiudad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    idVuelo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    capacidad = table.Column<int>(type: "int", nullable: false),
                    costo = table.Column<double>(type: "float", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    aerolinea = table.Column<string>(type: "varchar(512)", nullable: false),
                    avion = table.Column<string>(type: "varchar(50)", nullable: false),
                    idCiudadOrigen = table.Column<int>(type: "int", nullable: true),
                    idCiudadDestino = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.idVuelo);
                    table.ForeignKey(
                        name: "FK_Vuelos_Ciudades_idCiudadDestino",
                        column: x => x.idCiudadDestino,
                        principalTable: "Ciudades",
                        principalColumn: "idCiudad");
                    table.ForeignKey(
                        name: "FK_Vuelos_Ciudades_idCiudadOrigen",
                        column: x => x.idCiudadOrigen,
                        principalTable: "Ciudades",
                        principalColumn: "idCiudad");
                });

            migrationBuilder.CreateTable(
                name: "reservaHoteles",
                columns: table => new
                {
                    idHotel = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    fechaDesde = table.Column<DateTime>(type: "datetime", nullable: false),
                    fechaHasta = table.Column<DateTime>(type: "datetime", nullable: false),
                    pagado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservaHoteles", x => new { x.idUsuario, x.idHotel });
                    table.ForeignKey(
                        name: "FK_reservaHoteles_Hoteles_idHotel",
                        column: x => x.idHotel,
                        principalTable: "Hoteles",
                        principalColumn: "idHotel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservaHoteles_Usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservaVuelos",
                columns: table => new
                {
                    idVuelo = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    pagado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservaVuelos", x => new { x.idUsuario, x.idVuelo });
                    table.ForeignKey(
                        name: "FK_reservaVuelos_Usuarios_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservaVuelos_Vuelos_idVuelo",
                        column: x => x.idVuelo,
                        principalTable: "Vuelos",
                        principalColumn: "idVuelo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ciudades",
                columns: new[] { "idCiudad", "nombre" },
                values: new object[,]
                {
                    { 1, "Buenos Aires" },
                    { 2, "Berlin" }
                });

            migrationBuilder.InsertData(
                table: "Hoteles",
                columns: new[] { "idHotel", "capacidad", "costo", "idCiudad", "nombre" },
                values: new object[,]
                {
                    { 1, 150, 25000.0, null, "Four Seasons" },
                    { 2, 200, 15000.0, null, "Gat Point Charlie" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "apellido", "bloqueado", "credito", "dni", "esAdmin", "intentosFallidos", "mail", "nombre", "password" },
                values: new object[,]
                {
                    { 1, "Administrador", false, 0.0, 11222333, true, 0, "admin@agencia", "Admin", "12345" },
                    { 2, "Usuario", false, 15000.0, 22333444, false, 1, "user@agencia", "User", "56789" }
                });

            migrationBuilder.InsertData(
                table: "Vuelos",
                columns: new[] { "idVuelo", "aerolinea", "avion", "capacidad", "costo", "fecha", "idCiudadDestino", "idCiudadOrigen" },
                values: new object[,]
                {
                    { 1, "Aero", "LF-5909", 150, 600000.0, null, null, null },
                    { 2, "Aero", "LF-9501", 150, 650000.0, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "reservaHoteles",
                columns: new[] { "idHotel", "idUsuario", "fechaDesde", "fechaHasta", "pagado" },
                values: new object[] { 1, 2, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "reservaVuelos",
                columns: new[] { "idUsuario", "idVuelo", "pagado" },
                values: new object[,]
                {
                    { 2, 1, 1 },
                    { 2, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hoteles_idCiudad",
                table: "Hoteles",
                column: "idCiudad");

            migrationBuilder.CreateIndex(
                name: "IX_reservaHoteles_idHotel",
                table: "reservaHoteles",
                column: "idHotel");

            migrationBuilder.CreateIndex(
                name: "IX_reservaVuelos_idVuelo",
                table: "reservaVuelos",
                column: "idVuelo");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_idCiudadDestino",
                table: "Vuelos",
                column: "idCiudadDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Vuelos_idCiudadOrigen",
                table: "Vuelos",
                column: "idCiudadOrigen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservaHoteles");

            migrationBuilder.DropTable(
                name: "reservaVuelos");

            migrationBuilder.DropTable(
                name: "Hoteles");

            migrationBuilder.DropTable(
                name: "Vuelos");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "idUsuario",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "idUsuario",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Usuarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "mail",
                table: "Usuarios",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "intentosFallidos",
                table: "Usuarios",
                newName: "IntentosFallidos");

            migrationBuilder.RenameColumn(
                name: "esAdmin",
                table: "Usuarios",
                newName: "EsAdmin");

            migrationBuilder.RenameColumn(
                name: "dni",
                table: "Usuarios",
                newName: "DNI");

            migrationBuilder.RenameColumn(
                name: "credito",
                table: "Usuarios",
                newName: "Credito");

            migrationBuilder.RenameColumn(
                name: "bloqueado",
                table: "Usuarios",
                newName: "Bloqueado");

            migrationBuilder.RenameColumn(
                name: "apellido",
                table: "Usuarios",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "idUsuario",
                table: "Usuarios",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Mail",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(512)");

            migrationBuilder.AlterColumn<int>(
                name: "IntentosFallidos",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Credito",
                table: "Usuarios",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apellido",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");
        }
    }
}
