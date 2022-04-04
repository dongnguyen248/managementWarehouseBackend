using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CostAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Line",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CostCenter = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostAccountItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CostAccount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostAccountItem", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_CostAccountItem_CostAccount",
                        column: x => x.CostAccount,
                        principalTable: "CostAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Zone = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Item = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Specification = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_Material_Unit",
                        column: x => x.Unit,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_Material_Zone",
                        column: x => x.Zone,
                        principalTable: "Zone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExportHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Material = table.Column<int>(type: "int", nullable: false),
                    ExportDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Receiver = table.Column<int>(type: "int", nullable: false),
                    Requestor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Handler = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportHistory", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_ExportHistory_Handler",
                        column: x => x.Handler,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_ExportHistory_Material",
                        column: x => x.Material,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_ExportHistory_Receiver",
                        column: x => x.Receiver,
                        principalTable: "Line",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImportHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Material = table.Column<int>(type: "int", nullable: false),
                    ImportDate = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LineRequest = table.Column<int>(type: "int", nullable: false),
                    Buyer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PO = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Allocated = table.Column<bool>(type: "bit", nullable: false),
                    Handler = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportHistory", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_ImportHistory_Handler",
                        column: x => x.Handler,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_ImportHistory_LineRequest",
                        column: x => x.LineRequest,
                        principalTable: "Line",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Fk_ImportHistory_Material",
                        column: x => x.Material,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inspection",
                columns: table => new
                {
                    ImportId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Inspector = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Result = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inspecti__869767EA51B9482C", x => x.ImportId);
                    table.ForeignKey(
                        name: "Fk_Inspection_ImportHistory",
                        column: x => x.ImportId,
                        principalTable: "ImportHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UIdx_CostAccount_Name",
                table: "CostAccount",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CostAccountItem_CostAccount",
                table: "CostAccountItem",
                column: "CostAccount");

            migrationBuilder.CreateIndex(
                name: "UIdx_Employee_Code",
                table: "Employee",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportHistory_Handler",
                table: "ExportHistory",
                column: "Handler");

            migrationBuilder.CreateIndex(
                name: "IX_ExportHistory_Material",
                table: "ExportHistory",
                column: "Material");

            migrationBuilder.CreateIndex(
                name: "IX_ExportHistory_Receiver",
                table: "ExportHistory",
                column: "Receiver");

            migrationBuilder.CreateIndex(
                name: "IX_ImportHistory_Handler",
                table: "ImportHistory",
                column: "Handler");

            migrationBuilder.CreateIndex(
                name: "IX_ImportHistory_LineRequest",
                table: "ImportHistory",
                column: "LineRequest");

            migrationBuilder.CreateIndex(
                name: "IX_ImportHistory_Material",
                table: "ImportHistory",
                column: "Material");

            migrationBuilder.CreateIndex(
                name: "IX_Material_Unit",
                table: "Material",
                column: "Unit");

            migrationBuilder.CreateIndex(
                name: "IX_Material_Zone",
                table: "Material",
                column: "Zone");

            migrationBuilder.CreateIndex(
                name: "UIdx_Material_QCode",
                table: "Material",
                column: "QCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UIdx_Zone_Name",
                table: "Zone",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostAccountItem");

            migrationBuilder.DropTable(
                name: "ExportHistory");

            migrationBuilder.DropTable(
                name: "Inspection");

            migrationBuilder.DropTable(
                name: "CostAccount");

            migrationBuilder.DropTable(
                name: "ImportHistory");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Line");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Zone");
        }
    }
}
