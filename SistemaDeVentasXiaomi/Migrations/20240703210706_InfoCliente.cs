using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeVentasXiaomi.Migrations
{
    /// <inheritdoc />
    public partial class InfoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CI",
                table: "Clientes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CI",
                table: "Clientes");
        }
    }
}
