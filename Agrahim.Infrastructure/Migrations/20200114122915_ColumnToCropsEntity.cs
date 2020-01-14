using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrahim.Infrastructure.Migrations
{
    public partial class ColumnToCropsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CoefficientK",
                table: "CropsTypes",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CoefficientN",
                table: "CropsTypes",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CoefficientP",
                table: "CropsTypes",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoefficientK",
                table: "CropsTypes");

            migrationBuilder.DropColumn(
                name: "CoefficientN",
                table: "CropsTypes");

            migrationBuilder.DropColumn(
                name: "CoefficientP",
                table: "CropsTypes");
        }
    }
}
