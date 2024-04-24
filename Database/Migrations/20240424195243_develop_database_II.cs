using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class develop_database_II : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_ApplicationUserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Vege_Order_OrderId",
                table: "Order_Vege");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Vege_Vegetable_VegetablesID",
                table: "Order_Vege");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Vege",
                table: "Order_Vege");

            migrationBuilder.DropIndex(
                name: "IX_Order_Vege_OrderId",
                table: "Order_Vege");

            migrationBuilder.DropIndex(
                name: "IX_Order_Vege_VegetablesID",
                table: "Order_Vege");

            migrationBuilder.DropIndex(
                name: "IX_Order_ApplicationUserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Order_Vege");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Order_Vege");

            migrationBuilder.DropColumn(
                name: "VegetablesID",
                table: "Order_Vege");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "ID_User",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Vege",
                table: "Order_Vege",
                columns: new[] { "IdOrder", "IdVege" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Vege_IdVege",
                table: "Order_Vege",
                column: "IdVege");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ID_User",
                table: "Order",
                column: "ID_User");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_ID_User",
                table: "Order",
                column: "ID_User",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Vege_Order_IdOrder",
                table: "Order_Vege",
                column: "IdOrder",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Vege_Vegetable_IdVege",
                table: "Order_Vege",
                column: "IdVege",
                principalTable: "Vegetable",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_ID_User",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Vege_Order_IdOrder",
                table: "Order_Vege");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Vege_Vegetable_IdVege",
                table: "Order_Vege");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Vege",
                table: "Order_Vege");

            migrationBuilder.DropIndex(
                name: "IX_Order_Vege_IdVege",
                table: "Order_Vege");

            migrationBuilder.DropIndex(
                name: "IX_Order_ID_User",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Order_Vege",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Order_Vege",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VegetablesID",
                table: "Order_Vege",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID_User",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Vege",
                table: "Order_Vege",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Vege_OrderId",
                table: "Order_Vege",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Vege_VegetablesID",
                table: "Order_Vege",
                column: "VegetablesID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ApplicationUserId",
                table: "Order",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_ApplicationUserId",
                table: "Order",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Vege_Order_OrderId",
                table: "Order_Vege",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Vege_Vegetable_VegetablesID",
                table: "Order_Vege",
                column: "VegetablesID",
                principalTable: "Vegetable",
                principalColumn: "ID");
        }
    }
}
