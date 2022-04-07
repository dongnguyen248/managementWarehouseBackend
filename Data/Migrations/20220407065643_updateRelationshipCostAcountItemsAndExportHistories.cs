using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateRelationshipCostAcountItemsAndExportHistories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "costAccountItem",
                table: "ExportHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExportHistory_costAccountItem",
                table: "ExportHistory",
                column: "costAccountItem");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportHistory_CostAccountItem_costAccountItem",
                table: "ExportHistory",
                column: "costAccountItem",
                principalTable: "CostAccountItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportHistory_CostAccountItem_costAccountItem",
                table: "ExportHistory");

            migrationBuilder.DropIndex(
                name: "IX_ExportHistory_costAccountItem",
                table: "ExportHistory");

            migrationBuilder.DropColumn(
                name: "costAccountItem",
                table: "ExportHistory");
        }
    }
}
