using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPFMobile.Migrations
{
    /// <inheritdoc />
    public partial class PacienteIdade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pacienteIdade",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "pacienteSexo",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pacienteIdade",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "pacienteSexo",
                table: "Pacientes");
        }
    }
}
