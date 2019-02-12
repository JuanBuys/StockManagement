using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockManagement.API.Migrations
{
    public partial class StockManagementAPIModelsApplicationContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Action",
                schema: "dbo",
                columns: table => new
                {
                    ActionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true),
                    RoleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.ActionID);
                    table.ForeignKey(
                        name: "FK_Action_Role_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: true),
                    Password = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telephone = table.Column<string>(type: "varchar(30)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    LastChangeDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleAction",
                columns: table => new
                {
                    RoleActionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleID = table.Column<int>(nullable: false),
                    ActionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAction", x => x.RoleActionID);
                    table.ForeignKey(
                        name: "FK_RoleAction_Action_ActionID",
                        column: x => x.ActionID,
                        principalSchema: "dbo",
                        principalTable: "Action",
                        principalColumn: "ActionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleAction_Role_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockItem",
                schema: "dbo",
                columns: table => new
                {
                    StockItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastChangeByUserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItem", x => x.StockItemID);
                    table.ForeignKey(
                        name: "FK_StockItem_User_LastChangeByUserID",
                        column: x => x.LastChangeByUserID,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Action",
                columns: new[] { "ActionID", "Description", "Name", "RoleID" },
                values: new object[,]
                {
                    { 1, "Action assigned to allow adding new users", "Can add users", null },
                    { 2, "Action assigned to allow editing users", "Can edit users", null },
                    { 3, "Action assigned to allow deleting users", "Can delete user", null },
                    { 4, "Action assigned to allow adding new stock", "Can Add stock", null },
                    { 5, "Action assigned to allow editing stock", "Can edit stock", null },
                    { 6, "Action assigned to allow deleting stock", "Can delete stock", null },
                    { 7, "Acton assigned to a allow adding new system actions", "Can add action", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Role",
                columns: new[] { "RoleID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Role used by users that require admin access", "Admin" },
                    { 2, "Role used by users that do basic application functions", "User" },
                    { 3, "Role used by users that require access to stock", "StockController" },
                    { 4, "Role used by users that require view only access on application", "Guest" }
                });

            migrationBuilder.InsertData(
                table: "RoleAction",
                columns: new[] { "RoleActionID", "ActionID", "RoleID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 },
                    { 6, 6, 1 },
                    { 7, 7, 1 },
                    { 8, 2, 2 },
                    { 9, 5, 2 },
                    { 10, 4, 3 },
                    { 11, 5, 3 },
                    { 12, 6, 3 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "UserID", "DateOfBirth", "Email", "FirstName", "IsActive", "LastName", "Password", "RoleID", "Telephone" },
                values: new object[] { 1, new DateTime(2018, 1, 2, 15, 30, 45, 0, DateTimeKind.Unspecified), "glucas@email.co.za", "George", true, "Lucas", "G@Lucas101", 1, "0129876123" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "UserID", "DateOfBirth", "Email", "FirstName", "IsActive", "LastName", "Password", "RoleID", "Telephone" },
                values: new object[] { 3, new DateTime(2018, 1, 2, 15, 30, 59, 0, DateTimeKind.Unspecified), "asmith@email.co.za", "Abigail", true, "Smith", "G@Lucas101", 2, "0214758901" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "UserID", "DateOfBirth", "Email", "FirstName", "IsActive", "LastName", "Password", "RoleID", "Telephone" },
                values: new object[] { 2, new DateTime(1982, 5, 22, 15, 30, 11, 0, DateTimeKind.Unspecified), "juan@marshan.co.za", "Juan", true, "Buys", "juan@marshan.co.za", 3, "0415784120" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "StockItem",
                columns: new[] { "StockItemID", "DateCreated", "Description", "IsActive", "LastChangeByUserID", "Name", "Price", "Quantity" },
                values: new object[] { 1, new DateTime(2017, 11, 12, 9, 10, 45, 0, DateTimeKind.Unspecified), "Short metal like piece shaped to a spoon", true, 1, "Pap lepel", 25.65m, 500 });

            migrationBuilder.CreateIndex(
                name: "IX_RoleAction_ActionID",
                table: "RoleAction",
                column: "ActionID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAction_RoleID",
                table: "RoleAction",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Action_RoleID",
                schema: "dbo",
                table: "Action",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_LastChangeByUserID",
                schema: "dbo",
                table: "StockItem",
                column: "LastChangeByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleID",
                schema: "dbo",
                table: "User",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleAction");

            migrationBuilder.DropTable(
                name: "StockItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Action",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");
        }
    }
}
