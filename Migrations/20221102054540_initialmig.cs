using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interview.Api.Migrations
{
    public partial class initialmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    TranId = table.Column<string>(type: "TEXT", nullable: false),
                    TranDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TelecomId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CtyName = table.Column<string>(type: "TEXT", nullable: false),
                    CtyCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneNo = table.Column<string>(type: "TEXT", nullable: false),
                    CanTransact = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountNumber = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Balance = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CtyCode", "CtyName" },
                values: new object[] { 1, "Uganda", "Uganda" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CtyCode", "CtyName" },
                values: new object[] { 1002, "Usa", "Usa" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CtyCode", "CtyName" },
                values: new object[] { 1003, "England", "England" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CtyCode", "CtyName" },
                values: new object[] { 1004, "Kenya", "Kenya" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "EmailAddress", "FullName", "Password", "PhoneNumber" },
                values: new object[] { 1, "Nakawa, Bugolobi", "bk@gmail.com", "Benard Kalika", "104d3b20ba4ac5dc7f716f43cdc1aefa", "0785100504" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "EmailAddress", "FullName", "Password", "PhoneNumber" },
                values: new object[] { 2, "Julie, Nakato", "jn@gmail.com", "Julie Nakato", "ba1cdd46d798d5070e4a4711b24491bf", "0785100505" });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "CanTransact", "PhoneNo" },
                values: new object[] { 1, true, "075490901" });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "CanTransact", "PhoneNo" },
                values: new object[] { 2, true, "075490903" });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "CanTransact", "PhoneNo" },
                values: new object[] { 3, true, "075490501" });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "CanTransact", "PhoneNo" },
                values: new object[] { 4, true, "075490503" });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "CanTransact", "PhoneNo" },
                values: new object[] { 8, false, "075490305" });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "CanTransact", "PhoneNo" },
                values: new object[] { 9, false, "075490304" });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "CanTransact", "PhoneNo" },
                values: new object[] { 10, false, "075493506" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 1001, "This is a best gaming laptop", "Laptop", 20.02, 10 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 1002, "This is a Office Application", "Microsoft Office", 20.989999999999998, 50 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 1003, "The mouse that works on all surface", "Lazer Mouse", 12.02, 20 });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Description", "Name", "Price", "Quantity" },
                values: new object[] { 1004, "To store 256GB of data", "USB Storage", 5.0, 20 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "CustomerId" },
                values: new object[] { 1, "1000000001", 10450000, 1 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "CustomerId" },
                values: new object[] { 2, "1000000002", 450000, 1 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "CustomerId" },
                values: new object[] { 3, "1000000003", 10450000, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountTransactions");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
