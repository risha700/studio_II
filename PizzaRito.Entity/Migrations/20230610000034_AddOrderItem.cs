using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaRito.Entity.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pizzas_orders_OrderId",
                table: "pizzas");

            migrationBuilder.DropIndex(
                name: "IX_pizzas_OrderId",
                table: "pizzas");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "pizzas");

            migrationBuilder.CreateTable(
                name: "OrderPizza",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrdersId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizza", x => new { x.ItemsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_OrderPizza_orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizza_pizzas_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_OrdersId",
                table: "OrderPizza",
                column: "OrdersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPizza");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "pizzas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pizzas_OrderId",
                table: "pizzas",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_pizzas_orders_OrderId",
                table: "pizzas",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id");
        }
    }
}
