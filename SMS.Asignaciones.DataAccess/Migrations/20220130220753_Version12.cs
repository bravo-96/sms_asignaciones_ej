using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Asignaciones.DataAccess.Migrations
{
    public partial class Version12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubEquipoProyecto",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubEquipoId = table.Column<int>(type: "int", nullable: false),
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubEquipoProyecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubEquipoProyecto_Proyecto_ProyectoId",
                        column: x => x.ProyectoId,
                        principalSchema: "dbo",
                        principalTable: "Proyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubEquipoProyecto_SubEquipo_SubEquipoId",
                        column: x => x.SubEquipoId,
                        principalSchema: "dbo",
                        principalTable: "SubEquipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubEquipoProyecto_ProyectoId",
                schema: "dbo",
                table: "SubEquipoProyecto",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_SubEquipoProyecto_SubEquipoId",
                schema: "dbo",
                table: "SubEquipoProyecto",
                column: "SubEquipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubEquipoProyecto",
                schema: "dbo");
        }
    }
}
