using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class fixMoveRemartToImportHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "Material");

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "ImportHistory",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remark",
                table: "ImportHistory");

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "Material",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
