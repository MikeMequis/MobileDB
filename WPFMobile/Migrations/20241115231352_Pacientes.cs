using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPFMobile.Migrations
{
    /// <inheritdoc />
    public partial class Pacientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    pacienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pacienteNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pacienteCpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pacienteTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pacienteEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.pacienteId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}

// Migration commands:
// get-help EntityFrameworkCore
// Add-Migration <Migration-Name>
// Remove-Migration
// Update-Database
// Drop-Database