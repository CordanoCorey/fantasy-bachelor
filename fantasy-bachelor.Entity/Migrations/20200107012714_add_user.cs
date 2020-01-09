using Microsoft.EntityFrameworkCore.Migrations;

namespace fantasy_bachelor.Entity.Migrations
{
    public partial class add_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "es2531@ymail.com", "es2531@ymail.com", "es2531@ymail.com", "es2531@ymail.com" });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetCode", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 21, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "nkroof@yahoo.com", false, "Nancy", "Roof", false, null, "nkroof@yahoo.com", "nkroof@yahoo.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "nkroof@yahoo.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.UpdateData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "UserName" },
                values: new object[] { "es2531@gmail.com", "es2531@gmail.com", "es2531@gmail.com", "es2531@gmail.com" });
        }
    }
}
