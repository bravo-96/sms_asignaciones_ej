using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Asignaciones.DataAccess.Migrations
{
    public partial class Version9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaAlta",
                schema: "dbo",
                table: "Colaborador",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaBaja",
                schema: "dbo",
                table: "Colaborador",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubEquipo",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubEquipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubEquipo_Equipo_EquipoId",
                        column: x => x.EquipoId,
                        principalSchema: "dbo",
                        principalTable: "Equipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoLicencia",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLicencia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Licencia",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    TipoLicenciaId = table.Column<int>(type: "int", nullable: false),
                    Desde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hasta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Licencia_Colaborador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalSchema: "dbo",
                        principalTable: "Colaborador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Licencia_TipoLicencia_TipoLicenciaId",
                        column: x => x.TipoLicenciaId,
                        principalSchema: "dbo",
                        principalTable: "TipoLicencia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Licencia_ColaboradorId",
                schema: "dbo",
                table: "Licencia",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Licencia_TipoLicenciaId",
                schema: "dbo",
                table: "Licencia",
                column: "TipoLicenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_SubEquipo_EquipoId",
                schema: "dbo",
                table: "SubEquipo",
                column: "EquipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Licencia",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubEquipo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TipoLicencia",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "FechaAlta",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "FechaBaja",
                schema: "dbo",
                table: "Colaborador");
        }
    }
}
