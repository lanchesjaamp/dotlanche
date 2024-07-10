using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotLanches.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddQueueKeyAndSubmitTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorarioRegistro",
                table: "Pagamentos",
                newName: "RegisteredAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedToQueueAt",
                table: "Pedidos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedToQueueAt",
                table: "Pedidos");

            migrationBuilder.RenameColumn(
                name: "RegisteredAt",
                table: "Pagamentos",
                newName: "HorarioRegistro");
        }
    }
}
