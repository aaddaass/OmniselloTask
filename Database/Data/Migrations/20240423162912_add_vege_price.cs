using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmniselloTask.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_vege_price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "VegaetablesPrice",
                table: "Vegetable",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VegaetablesPrice",
                table: "Vegetable");
        }
    }
}
