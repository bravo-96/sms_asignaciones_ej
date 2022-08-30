using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Asignaciones.DataAccess.Migrations
{
    public partial class Version10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LiderSubEquipo",
                schema: "dbo",
                table: "Colaborador",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubEquipoId",
                schema: "dbo",
                table: "Colaborador",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_SubEquipoId",
                schema: "dbo",
                table: "Colaborador",
                column: "SubEquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_SubEquipo_SubEquipoId",
                schema: "dbo",
                table: "Colaborador",
                column: "SubEquipoId",
                principalSchema: "dbo",
                principalTable: "SubEquipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_SubEquipo_SubEquipoId",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_SubEquipoId",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "LiderSubEquipo",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "SubEquipoId",
                schema: "dbo",
                table: "Colaborador");
        }
    }
}
