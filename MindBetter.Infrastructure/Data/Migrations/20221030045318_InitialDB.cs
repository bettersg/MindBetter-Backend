using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MindBetter.Infrastructure.Data.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NonProfit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    WebsiteURL = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonProfit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionTypesLookup",
                columns: table => new
                {
                    EnumVal = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionTypesLookup", x => x.EnumVal);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategoryLookup",
                columns: table => new
                {
                    EnumVal = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategoryLookup", x => x.EnumVal);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    NonProfitId = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_NonProfit_NonProfitId",
                        column: x => x.NonProfitId,
                        principalTable: "NonProfit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NonProfitMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Designation = table.Column<string>(type: "TEXT", nullable: false),
                    NonProfitId = table.Column<int>(type: "INTEGER", nullable: false),
                    PermissionType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonProfitMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonProfitMember_NonProfit_NonProfitId",
                        column: x => x.NonProfitId,
                        principalTable: "NonProfit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NonProfitMember_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PermissionTypesLookup",
                columns: new[] { "EnumVal", "Description", "Name" },
                values: new object[] { 1, "Administrator", "Admin" });

            migrationBuilder.InsertData(
                table: "PermissionTypesLookup",
                columns: new[] { "EnumVal", "Description", "Name" },
                values: new object[] { 2, "Editor", "Editor" });

            migrationBuilder.InsertData(
                table: "PermissionTypesLookup",
                columns: new[] { "EnumVal", "Description", "Name" },
                values: new object[] { 3, "Member", "Member" });

            migrationBuilder.InsertData(
                table: "ServiceCategoryLookup",
                columns: new[] { "EnumVal", "Description", "Name" },
                values: new object[] { 1, "Cat1", "Cat1" });

            migrationBuilder.InsertData(
                table: "ServiceCategoryLookup",
                columns: new[] { "EnumVal", "Description", "Name" },
                values: new object[] { 2, "Cat2", "Cat2" });

            migrationBuilder.InsertData(
                table: "ServiceCategoryLookup",
                columns: new[] { "EnumVal", "Description", "Name" },
                values: new object[] { 3, "Cat3", "Cat3" });

            migrationBuilder.CreateIndex(
                name: "IX_NonProfitMember_NonProfitId",
                table: "NonProfitMember",
                column: "NonProfitId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_NonProfitId",
                table: "Service",
                column: "NonProfitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NonProfitMember");

            migrationBuilder.DropTable(
                name: "PermissionTypesLookup");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "ServiceCategoryLookup");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "NonProfit");
        }
    }
}
