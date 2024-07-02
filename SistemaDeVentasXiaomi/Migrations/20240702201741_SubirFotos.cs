using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeVentasXiaomi.Migrations
{
    /// <inheritdoc />
    public partial class SubirFotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlFoto",
                table: "Televisores",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlFoto",
                table: "Televisores");
        }
    }
}
