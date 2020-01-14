using Microsoft.EntityFrameworkCore.Migrations;

namespace fantasy_bachelor.Entity.Migrations
{
    public partial class add_users_10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Auth",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetCode", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 35, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "morgan.ciecierski10@gmail.com", false, "Morgan", "", false, null, "morgan.ciecierski10@gmail.com", "morgan.ciecierski10@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "morgan.ciecierski10@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 35);
        }
    }
}
