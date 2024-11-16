using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPFMobile.Migrations
{
    /// <inheritdoc />
    public partial class Correcao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConsultaDataHora",
                table: "Consultas",
                newName: "ConsultaData");

            migrationBuilder.AddColumn<string>(
                name: "ConsultaHora",
                table: "Consultas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsultaHora",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "ConsultaData",
                table: "Consultas",
                newName: "ConsultaDataHora");
        }
    }
}
