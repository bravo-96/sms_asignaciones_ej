using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Asignaciones.DataAccess.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                schema: "dbo",
                table: "Colaborador",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Proveedor",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_ProveedorId",
                schema: "dbo",
                table: "Colaborador",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Proveedor_ProveedorId",
                schema: "dbo",
                table: "Colaborador",
                column: "ProveedorId",
                principalSchema: "dbo",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Proveedor_ProveedorId",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropTable(
                name: "Proveedor",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_ProveedorId",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                schema: "dbo",
                table: "Colaborador");
        }
    }
}
