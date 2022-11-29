using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiCasinoPIA.Migrations
{
    /// <inheritdoc />
    public partial class Tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Premios_Participantes_ParticipanteId",
                table: "Premios");

            migrationBuilder.DropForeignKey(
                name: "FK_Premios_Rifas_RifaId",
                table: "Premios");

            migrationBuilder.AlterColumn<int>(
                name: "RifaId",
                table: "Premios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipanteId",
                table: "Premios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Premios_Participantes_ParticipanteId",
                table: "Premios",
                column: "ParticipanteId",
                principalTable: "Participantes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Premios_Rifas_RifaId",
                table: "Premios",
                column: "RifaId",
                principalTable: "Rifas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Premios_Participantes_ParticipanteId",
                table: "Premios");

            migrationBuilder.DropForeignKey(
                name: "FK_Premios_Rifas_RifaId",
                table: "Premios");

            migrationBuilder.AlterColumn<int>(
                name: "RifaId",
                table: "Premios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParticipanteId",
                table: "Premios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Premios_Participantes_ParticipanteId",
                table: "Premios",
                column: "ParticipanteId",
                principalTable: "Participantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Premios_Rifas_RifaId",
                table: "Premios",
                column: "RifaId",
                principalTable: "Rifas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
