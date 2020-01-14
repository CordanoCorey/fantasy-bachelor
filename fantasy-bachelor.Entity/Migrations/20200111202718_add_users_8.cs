using Microsoft.EntityFrameworkCore.Migrations;

namespace fantasy_bachelor.Entity.Migrations
{
    public partial class add_users_8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Auth",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetCode", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 31, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "addieorndorff@gmail.com", false, "Addie", "Orndorff", false, null, "addieorndorff@gmail.com", "addieorndorff@gmail.com", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "addieorndorff@gmail.com" });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordResetCode", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 32, 0, "b39b7fd6-391c-4d74-ae0c-14a75b78866d", "rmo104@psu.edu", false, "Bob", "Orndorff", false, null, "rmo104@psu.edu", "rmo104@psu.edu", "AQAAAAEAACcQAAAAELOBJuVxexUotv2KcwjrXvL1y7w0fqQDt0OZqrA9SBRw2KUWbDCzhlJPFU7Y7P+u7Q==", null, null, false, "YSMHWI6B5ZHJFY4JDYXCHTUO52NXZWXB", false, "rmo104@psu.edu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "Auth",
                table: "User",
                keyColumn: "Id",
                keyValue: 32);
        }
    }
}
