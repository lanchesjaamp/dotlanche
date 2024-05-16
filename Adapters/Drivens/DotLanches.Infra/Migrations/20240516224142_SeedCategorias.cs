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
            migrationBuilder.InsertData("Categorias", "Name", "Lanches");
            migrationBuilder.InsertData("Categorias", "Name", "Acompanhamentos");
            migrationBuilder.InsertData("Categorias", "Name", "Bebidas");
            migrationBuilder.InsertData("Categorias", "Name", "Sobremesas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Categorias", "Name", "Lanches");
            migrationBuilder.DeleteData("Categorias", "Name", "Acompanhamentos");
            migrationBuilder.DeleteData("Categorias", "Name", "Bebidas");
            migrationBuilder.DeleteData("Categorias", "Name", "Sobremesas");
        }
    }
}
