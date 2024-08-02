using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasperAPI.Migrations
{
    /// <inheritdoc />
    public partial class Empleados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nombres = table.Column<string>(type: "varchar(25)", nullable: false),
                    PrimerApellido = table.Column<string>(type: "varchar(25)", nullable: false),
                    SegundoApellido = table.Column<string>(type: "varchar(25)", nullable: true),
                    FechaDeNacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    CURP = table.Column<string>(type: "varchar(18)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
