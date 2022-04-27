using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fixInvertories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportHistory_CostAccount_costAccount",
                table: "ExportHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportHistory_CostAccountItem_costAccountItem",
                table: "ExportHistory");

            migrationBuilder.DropColumn(
                name: "inventoriesAfter",
                table: "ExportHistory");

            migrationBuilder.RenameColumn(
                name: "inventoriesBefor",
                table: "ExportHistory",
                newName: "InventoriesBefor");

            migrationBuilder.RenameColumn(
                name: "costAccountItem",
                table: "ExportHistory",
                newName: "CostAccountItem");

            migrationBuilder.RenameColumn(
                name: "costAccount",
                table: "ExportHistory",
                newName: "CostAccount");

            migrationBuilder.RenameIndex(
                name: "IX_ExportHistory_costAccountItem",
                table: "ExportHistory",
                newName: "IX_ExportHistory_CostAccountItem");

            migrationBuilder.RenameIndex(
                name: "IX_ExportHistory_costAccount",
                table: "ExportHistory",
                newName: "IX_ExportHistory_CostAccount");

            migrationBuilder.AddForeignKey(
                name: "FK_ExportHistory_CostAccount_CostAccount",
                table: "ExportHistory",
                column: "CostAccount",
                principalTable: "CostAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportHistory_CostAccountItem_CostAccountItem",
                table: "ExportHistory",
                column: "CostAccountItem",
                principalTable: "CostAccountItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExportHistory_CostAccount_CostAccount",
                table: "ExportHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ExportHistory_CostAccountItem_CostAccountItem",
                table: "ExportHistory");

            migrationBuilder.RenameColumn(
                name: "InventoriesBefor",
                table: "ExportHistory",
                newName: "inventoriesBefor");

            migrationBuilder.RenameColumn(
                name: "CostAccountItem",
                table: "ExportHistory",
                newName: "costAccountItem");

            migrationBuilder.RenameColumn(
                name: "CostAccount",
                table: "ExportHistory",
                newName: "costAccount");

            migrationBuilder.RenameIndex(
                name: "IX_ExportHistory_CostAccountItem",
                table: "ExportHistory",
                newName: "IX_ExportHistory_costAccountItem");

            migrationBuilder.RenameIndex(
                name: "IX_ExportHistory_CostAccount",
                table: "ExportHistory",
                newName: "IX_ExportHistory_costAccount");

            migrationBuilder.AddColumn<int>(
                name: "inventoriesAfter",
                table: "ExportHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportHistory_CostAccount_costAccount",
                table: "ExportHistory",
                column: "costAccount",
                principalTable: "CostAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExportHistory_CostAccountItem_costAccountItem",
                table: "ExportHistory",
                column: "costAccountItem",
                principalTable: "CostAccountItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
