using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fixInventoriesExportHistories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "inventories",
                table: "ExportHistory",
                newName: "inventoriesBefor");

            migrationBuilder.AddColumn<int>(
                name: "inventoriesAfter",
                table: "ExportHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "inventoriesAfter",
                table: "ExportHistory");

            migrationBuilder.RenameColumn(
                name: "inventoriesBefor",
                table: "ExportHistory",
                newName: "inventories");
        }
    }
}
