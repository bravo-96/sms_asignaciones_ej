using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Asignaciones.DataAccess.Migrations
{
    public partial class Version4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Colaborador",
                type: "nvarchar(320)",
                maxLength: 320,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                schema: "dbo",
                table: "Colaborador",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "Colaborador",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                schema: "dbo",
                table: "Colaborador",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_RolId",
                schema: "dbo",
                table: "Colaborador",
                column: "RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Rol_RolId",
                schema: "dbo",
                table: "Colaborador",
                column: "RolId",
                principalSchema: "dbo",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Rol_RolId",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Colaborador_RolId",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Foto",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "dbo",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "RolId",
                schema: "dbo",
                table: "Colaborador");
        }
    }
}
