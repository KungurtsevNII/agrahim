using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrahim.Infrastructure.Migrations
{
    public partial class AddFieldIsRemovedToCropsType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "CropsTypes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "CropsTypes");
        }
    }
}
