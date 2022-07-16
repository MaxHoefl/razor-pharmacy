using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Razor.Pharmacy.Infrastructure.Persistence.Migrations
{
    public partial class Relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerClientId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerClientId",
                table: "Baskets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerClientId",
                table: "Orders",
                column: "CustomerClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_CustomerClientId",
                table: "Baskets",
                column: "CustomerClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Customers_CustomerClientId",
                table: "Baskets",
                column: "CustomerClientId",
                principalTable: "Customers",
                principalColumn: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerClientId",
                table: "Orders",
                column: "CustomerClientId",
                principalTable: "Customers",
                principalColumn: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Customers_CustomerClientId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerClientId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerClientId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_CustomerClientId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "CustomerClientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerClientId",
                table: "Baskets");
        }
    }
}
