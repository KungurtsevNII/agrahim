using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrahim.Infrastructure.Migrations
{
    public partial class AddEntityCrops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 200, nullable: false, computedColumnSql: "UPPER([Name])"),
                    CropsTypeId = table.Column<long>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crops_CropsTypes_CropsTypeId",
                        column: x => x.CropsTypeId,
                        principalTable: "CropsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crops_CropsTypeId",
                table: "Crops",
                column: "CropsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_NormalizedName",
                table: "Crops",
                column: "NormalizedName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crops");
        }
    }
}
