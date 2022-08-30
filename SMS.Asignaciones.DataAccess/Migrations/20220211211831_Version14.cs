using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Asignaciones.DataAccess.Migrations
{
    public partial class Version14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lider",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "LiderSubEquipo",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.AddColumn<int>(
                name: "LiderColaboradorId",
                schema: "dbo",
                table: "Colaborador",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_LiderColaboradorId",
                schema: "dbo",
                table: "Colaborador",
                column: "LiderColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Colaborador_LiderColaboradorId",
                schema: "dbo",
                table: "Colaborador",
                column: "LiderColaboradorId",
                principalSchema: "dbo",
                principalTable: "Colaborador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Colaborador_LiderColaboradorId",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_LiderColaboradorId",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "LiderColaboradorId",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.AddColumn<bool>(
                name: "Lider",
                schema: "dbo",
                table: "Colaborador",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LiderSubEquipo",
                schema: "dbo",
                table: "Colaborador",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
