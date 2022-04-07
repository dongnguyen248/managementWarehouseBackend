using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class updateDepartmentAndRemartExportHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "ExportHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "ExportHistory",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(95)", maxLength: 95, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportHistory_Department",
                table: "ExportHistory",
                column: "Department");

            migrationBuilder.AddForeignKey(
                name: "Fk_EmportHistory_Deparment",
                table: "ExportHistory",
                column: "Department",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_EmportHistory_Deparment",
                table: "ExportHistory");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_ExportHistory_Department",
                table: "ExportHistory");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "ExportHistory");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "ExportHistory");
        }
    }
}
