using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPFMobile.Migrations
{
    /// <inheritdoc />
    public partial class Correcao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConsultaData",
                table: "Consultas",
                newName: "ConsultaDataHora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConsultaDataHora",
                table: "Consultas",
                newName: "ConsultaData");
        }
    }
}
