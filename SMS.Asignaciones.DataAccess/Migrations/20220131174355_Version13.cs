using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Asignaciones.DataAccess.Migrations
{
    public partial class Version13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "LiderSubEquipo",
                schema: "dbo",
                table: "Colaborador",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "LiderSubEquipo",
                schema: "dbo",
                table: "Colaborador",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
