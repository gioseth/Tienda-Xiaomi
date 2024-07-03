using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeVentasXiaomi.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionModeloVenta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Vendedores_VendedorId",
                table: "Ventas");

            migrationBuilder.AlterColumn<int>(
                name: "VendedorId",
                table: "Ventas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "FechaVenta",
                table: "Ventas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Anio",
                table: "Ventas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "Ventas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Mes",
                table: "Ventas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NroVenta",
                table: "Ventas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PrecioUnidad",
                table: "Ventas",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Vendedores_VendedorId",
                table: "Ventas",
                column: "VendedorId",
                principalTable: "Vendedores",
                principalColumn: "VendedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Vendedores_VendedorId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Anio",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Mes",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "NroVenta",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "PrecioUnidad",
                table: "Ventas");

            migrationBuilder.AlterColumn<int>(
                name: "VendedorId",
                table: "Ventas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaVenta",
                table: "Ventas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Vendedores_VendedorId",
                table: "Ventas",
                column: "VendedorId",
                principalTable: "Vendedores",
                principalColumn: "VendedorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
