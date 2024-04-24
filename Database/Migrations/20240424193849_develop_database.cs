using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class develop_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VegaetablesPrice",
                table: "Vegetable",
                newName: "VegetablesPrice");

            migrationBuilder.RenameColumn(
                name: "NameVegatables",
                table: "Vegetable",
                newName: "VegetablesUnit");

            migrationBuilder.AddColumn<string>(
                name: "NameVegetables",
                table: "Vegetable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderAmount = table.Column<double>(type: "float", nullable: true),
                    ID_User = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order_Vege",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVege = table.Column<int>(type: "int", nullable: false),
                    VegetablesID = table.Column<int>(type: "int", nullable: true),
                    IdOrder = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Vege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Vege_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Vege_Vegetable_VegetablesID",
                        column: x => x.VegetablesID,
                        principalTable: "Vegetable",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_ApplicationUserId",
                table: "Order",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Vege_OrderId",
                table: "Order_Vege",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Vege_VegetablesID",
                table: "Order_Vege",
                column: "VegetablesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Vege");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropColumn(
                name: "NameVegetables",
                table: "Vegetable");

            migrationBuilder.RenameColumn(
                name: "VegetablesUnit",
                table: "Vegetable",
                newName: "NameVegatables");

            migrationBuilder.RenameColumn(
                name: "VegetablesPrice",
                table: "Vegetable",
                newName: "VegaetablesPrice");
        }
    }
}
