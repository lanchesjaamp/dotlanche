using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotLanches.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Categorias", "NAME", "Lanches");
            migrationBuilder.InsertData("Categorias", "NAME", "Acompanhamentos");
            migrationBuilder.InsertData("Categorias", "NAME", "Bebidas");
            migrationBuilder.InsertData("Categorias", "NAME", "Sobremesas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Categorias", "NAME", "Lanches");
            migrationBuilder.DeleteData("Categorias", "NAME", "Acompanhamentos");
            migrationBuilder.DeleteData("Categorias", "NAME", "Bebidas");
            migrationBuilder.DeleteData("Categorias", "NAME", "Sobremesas");
        }
    }
}