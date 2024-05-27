using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DotLanches.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddPagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Status_StatusId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Status",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QueueKey",
                table: "Pedidos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPedido = table.Column<int>(type: "integer", nullable: false),
                    IsAccepted = table.Column<bool>(type: "boolean", nullable: true),
                    HorarioRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Status_StatusId",
                table: "Pedidos",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Status_StatusId",
                table: "Pedidos");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "QueueKey",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Status",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Pedidos",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Status_StatusId",
                table: "Pedidos",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id");
        }
    }
}
