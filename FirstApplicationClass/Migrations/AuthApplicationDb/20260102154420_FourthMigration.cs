using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstApplicationClass.Migrations.AuthApplicationDb
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86162c9c-78fa-417c-abeb-c7e28ce4d560");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8b7d1fd-b085-47e4-9244-e00e75240c99");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "86162c9c-78fa-417c-abeb-c7e28ce4d560", 0, "790d60f8-cdc2-43e1-b600-4ae887fe0815", "admin@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEN/SrbnZrW+CeI7x0AppGn5OgmX0NJ3FSZCk/pJq4bWBWInbWyv5kJg/Wjvs5Unr5w==", null, false, "3600a8fd-1ed5-4c24-8c01-2b1c145409c9", false, "admin@gmail.com" },
                    { "a8b7d1fd-b085-47e4-9244-e00e75240c99", 0, "6242145f-4076-40ef-8d18-d6d3a3f2daee", "user@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAELzto1Y3/+AOARm5e2dcv/LBBy3vmP+0N2Amn3b9UU0B0j8kWivP+ZRyHKiok3cVZQ==", null, false, "69ff9011-6dd3-405b-ab8d-61b66e8cfa0b", false, "user@gmail.com" }
                });
        }
    }
}
