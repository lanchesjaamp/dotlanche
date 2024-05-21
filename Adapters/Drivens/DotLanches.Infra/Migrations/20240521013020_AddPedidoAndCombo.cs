using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DotLanches.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddPedidoAndCombo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Clientes_Cpf",
                table: "Clientes",
                column: "Cpf");

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ClienteCPF = table.Column<string>(type: "text", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_ClienteCPF",
                        column: x => x.ClienteCPF,
                        principalTable: "Clientes",
                        principalColumn: "Cpf");
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PedidoId = table.Column<int>(type: "integer", nullable: false),
                    LancheId = table.Column<int>(type: "integer", nullable: true),
                    LancheName = table.Column<string>(type: "text", nullable: true),
                    AcompanhamentoId = table.Column<int>(type: "integer", nullable: true),
                    AcompanhamentoName = table.Column<string>(type: "text", nullable: true),
                    BebidaId = table.Column<int>(type: "integer", nullable: true),
                    BebidaName = table.Column<string>(type: "text", nullable: true),
                    SobremesaId = table.Column<int>(type: "integer", nullable: true),
                    SobremesaName = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Combos_Produtos_AcompanhamentoId",
                        column: x => x.AcompanhamentoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Combos_Produtos_BebidaId",
                        column: x => x.BebidaId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Combos_Produtos_LancheId",
                        column: x => x.LancheId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Combos_Produtos_SobremesaId",
                        column: x => x.SobremesaId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Combos_AcompanhamentoId",
                table: "Combos",
                column: "AcompanhamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_BebidaId",
                table: "Combos",
                column: "BebidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_LancheId",
                table: "Combos",
                column: "LancheId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_PedidoId",
                table: "Combos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_SobremesaId",
                table: "Combos",
                column: "SobremesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteCPF",
                table: "Pedidos",
                column: "ClienteCPF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Clientes_Cpf",
                table: "Clientes");
        }
    }
}
