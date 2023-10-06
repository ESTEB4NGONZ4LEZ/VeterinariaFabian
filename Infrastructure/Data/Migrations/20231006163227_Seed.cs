using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Especialidades",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "...", "Cirujano Vascular" },
                    { 2, "...", "Terapia" },
                    { 3, "...", "Psicologo" },
                    { 4, "...", "Enfermera" }
                });

            migrationBuilder.InsertData(
                table: "Especies",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Felino" },
                    { 2, "Canino" }
                });

            migrationBuilder.InsertData(
                table: "Laboratorios",
                columns: new[] { "Id", "Direccion", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Calle labora 1 ", "Genfar", "435234234" },
                    { 2, "Calle labora 2", "Laboratorio 1", "435234234" },
                    { 3, "Calle labora 3", "Laboratorio 2", "435234234" },
                    { 4, "Calle labora 4", "Laboratorio 3", "435234234" }
                });

            migrationBuilder.InsertData(
                table: "Propietario",
                columns: new[] { "Id", "Email", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "esteban@gmail.com", "Esteban", "213123123" },
                    { 2, "propietario1@gmail.com", "Propietario1", "213123123" },
                    { 3, "propietario2@gmail.com", "Propietario2", "213123123" },
                    { 4, "propietario3@gmail.com", "Propietario3", "213123123" }
                });

            migrationBuilder.InsertData(
                table: "mascota",
                columns: new[] { "Id", "EspecieId", "FechaNacimiento", "Nombre", "PropietarioId" },
                values: new object[,]
                {
                    { 1, 2, new DateOnly(2019, 7, 3), "Mini", 1 },
                    { 2, 2, new DateOnly(2020, 6, 3), "Mascota 1", 2 },
                    { 3, 1, new DateOnly(2017, 1, 3), "Mascota 2", 3 },
                    { 4, 1, new DateOnly(2019, 8, 3), "Mascota 3", 4 }
                });

            migrationBuilder.InsertData(
                table: "medicamento",
                columns: new[] { "Id", "CantidadDisponible", "LaboratorioId", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, 20, 1, "Medicamento 1", 56000.0 },
                    { 2, 12, 1, "Medicamento 2", 67000.0 },
                    { 3, 65, 2, "Medicamento 3", 10000.0 },
                    { 4, 32, 3, "Medicamento 4", 16500.0 }
                });

            migrationBuilder.InsertData(
                table: "raza",
                columns: new[] { "Id", "EspecieId", "Nombre" },
                values: new object[,]
                {
                    { 1, 2, "Bull Dog" },
                    { 2, 2, "Pincher" },
                    { 3, 1, "Leon" },
                    { 4, 1, "Gato" },
                    { 5, 1, "Tigrillo" }
                });

            migrationBuilder.InsertData(
                table: "veterinario",
                columns: new[] { "Id", "Email", "EspecialidadId", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "veterinario1@gmail.com", 1, "Veterinario 1", "4352345" },
                    { 2, "veterinario2@gmail.com", 1, "Veterinario 2", "4352345" },
                    { 3, "veterinario3@gmail.com", 2, "Veterinario 3", "4352345" },
                    { 4, "veterinario4@gmail.com", 3, "Veterinario 4", "4352345" }
                });

            migrationBuilder.InsertData(
                table: "cita",
                columns: new[] { "Id", "Fecha", "MascotaId", "Motivo", "VeterinarioId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vacunacion recien nacido", 1 },
                    { 2, new DateTime(2022, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Revicion preventiva", 2 },
                    { 3, new DateTime(2023, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Vacunacion contra pulgas", 3 },
                    { 4, new DateTime(2021, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Terapias", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Laboratorios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "cita",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "medicamento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "medicamento",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "medicamento",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "medicamento",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "raza",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "raza",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "raza",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "raza",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "raza",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Laboratorios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Laboratorios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Laboratorios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "mascota",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "veterinario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "veterinario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "veterinario",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "veterinario",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Especies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Propietario",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Propietario",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Propietario",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Propietario",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
