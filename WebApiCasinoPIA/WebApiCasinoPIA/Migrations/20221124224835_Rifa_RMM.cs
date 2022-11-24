using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiCasinoPIA.Migrations
{
    /// <inheritdoc />
    public partial class RifaRMM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rifas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rifas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantesRifas",
                columns: table => new
                {
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    RifaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantesRifas", x => new { x.ParticipanteId, x.RifaId });
                    table.ForeignKey(
                        name: "FK_ParticipantesRifas_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantesRifas_Rifas_RifaId",
                        column: x => x.RifaId,
                        principalTable: "Rifas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantesRifas_RifaId",
                table: "ParticipantesRifas",
                column: "RifaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantesRifas");

            migrationBuilder.DropTable(
                name: "Rifas");
        }
    }
}
