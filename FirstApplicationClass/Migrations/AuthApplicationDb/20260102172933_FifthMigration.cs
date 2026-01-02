using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstApplicationClass.Migrations.AuthApplicationDb
{
    /// <inheritdoc />
    public partial class FifthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user", "b1a48dc1-7127-4d93-8899-d9f9b784d016" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin", "d11f7fb0-1a33-44f4-8e9f-da0d0dcf28ca" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1a48dc1-7127-4d93-8899-d9f9b784d016");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d11f7fb0-1a33-44f4-8e9f-da0d0dcf28ca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b1a48dc1-7127-4d93-8899-d9f9b784d016", 0, "c837818c-5d11-4feb-85f9-a51faa49cc00", "user@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEICY/omvC2g66sA4c91xi8Qswa7GuUnWH3hA7OkC1BhKATzT043NsYRt7gP2dLCKGQ==", null, false, "023a02c6-8306-4558-8dbf-09709e621b96", false, "user@gmail.com" },
                    { "d11f7fb0-1a33-44f4-8e9f-da0d0dcf28ca", 0, "9892fd88-93a9-4bb1-935a-748242ed023a", "admin@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEAjqt/NK7gYOHQzD87EhWrbWcOyhFtGUZ98lQt+0wectwu7/+UwP+c4jpWQa7edI1Q==", null, false, "370e25c0-90a0-4c76-9ea5-d339cb3e6490", false, "admin@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "user", "b1a48dc1-7127-4d93-8899-d9f9b784d016" },
                    { "admin", "d11f7fb0-1a33-44f4-8e9f-da0d0dcf28ca" }
                });
        }
    }
}
