using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CasperAPI.Migrations
{
    /// <inheritdoc />
    public partial class UniqueCurp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CURP",
                table: "Empleados",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_CURP",
                table: "Empleados",
                column: "CURP",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Empleados_CURP",
                table: "Empleados");

            migrationBuilder.AlterColumn<string>(
                name: "CURP",
                table: "Empleados",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
