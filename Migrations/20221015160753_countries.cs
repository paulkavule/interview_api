using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Interview.Api.Migrations
{
    public partial class countries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
