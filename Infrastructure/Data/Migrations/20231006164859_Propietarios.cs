using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Propietarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mascota_Propietario_PropietarioId",
                table: "mascota");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Propietario",
                table: "Propietario");

            migrationBuilder.RenameTable(
                name: "Propietario",
                newName: "Propietarios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Propietarios",
                table: "Propietarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_mascota_Propietarios_PropietarioId",
                table: "mascota",
                column: "PropietarioId",
                principalTable: "Propietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mascota_Propietarios_PropietarioId",
                table: "mascota");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Propietarios",
                table: "Propietarios");

            migrationBuilder.RenameTable(
                name: "Propietarios",
                newName: "Propietario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Propietario",
                table: "Propietario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_mascota_Propietario_PropietarioId",
                table: "mascota",
                column: "PropietarioId",
                principalTable: "Propietario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
