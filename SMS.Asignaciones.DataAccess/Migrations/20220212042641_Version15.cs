using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Asignaciones.DataAccess.Migrations
{
    public partial class Version15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HorasVariables",
                schema: "dbo",
                table: "Colaborador",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorasVariables",
                schema: "dbo",
                table: "Colaborador");
        }
    }
}
