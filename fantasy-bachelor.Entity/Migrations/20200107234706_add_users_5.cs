using Microsoft.EntityFrameworkCore.Migrations;

namespace fantasy_bachelor.Entity.Migrations
{
    public partial class add_users_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Kaitlin", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Beth", "Morgan" });
        }
    }
}
