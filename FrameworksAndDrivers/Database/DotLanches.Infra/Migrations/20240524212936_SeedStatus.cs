using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotLanches.Infra.Migrations
{
    /// <inheritdoc />
    public partial class SeedStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Status", "Name", "Confirmado");
            migrationBuilder.InsertData("Status", "Name", "Recebido");
            migrationBuilder.InsertData("Status", "Name", "EmPreparacao");
            migrationBuilder.InsertData("Status", "Name", "Pronto");
            migrationBuilder.InsertData("Status", "Name", "Finalizado");
            migrationBuilder.InsertData("Status", "Name", "Cancelado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Status", "Name", "Confirmado");
            migrationBuilder.DeleteData("Status", "Name", "Recebido");
            migrationBuilder.DeleteData("Status", "Name", "EmPreparacao");
            migrationBuilder.DeleteData("Status", "Name", "Pronto");
            migrationBuilder.DeleteData("Status", "Name", "Finalizado");
            migrationBuilder.DeleteData("Status", "Name", "Cancelado");
        }
    }
}
