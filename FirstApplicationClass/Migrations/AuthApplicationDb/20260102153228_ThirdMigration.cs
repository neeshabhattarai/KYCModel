using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstApplicationClass.Migrations.AuthApplicationDb
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2adff3c8-a9ab-4cb7-bda5-b3fec45db951");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d763604-4cd3-46cb-b308-b2e48b1b8e5b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "86162c9c-78fa-417c-abeb-c7e28ce4d560", 0, "790d60f8-cdc2-43e1-b600-4ae887fe0815", "admin@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEN/SrbnZrW+CeI7x0AppGn5OgmX0NJ3FSZCk/pJq4bWBWInbWyv5kJg/Wjvs5Unr5w==", null, false, "3600a8fd-1ed5-4c24-8c01-2b1c145409c9", false, "admin@gmail.com" },
                    { "a8b7d1fd-b085-47e4-9244-e00e75240c99", 0, "6242145f-4076-40ef-8d18-d6d3a3f2daee", "user@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAELzto1Y3/+AOARm5e2dcv/LBBy3vmP+0N2Amn3b9UU0B0j8kWivP+ZRyHKiok3cVZQ==", null, false, "69ff9011-6dd3-405b-ab8d-61b66e8cfa0b", false, "user@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "2adff3c8-a9ab-4cb7-bda5-b3fec45db951", 0, "ec64a959-2562-4380-b45f-572ce515fcc6", "admin@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEO8maQKoz9Owc8v619v9WLiPSQDfm/hKyrAY1WeQtnyMdrmaTUJ7KJWYu7qjV/ykXA==", null, false, "66cfd7b1-63e4-4c8a-85a3-eba2687159a2", false, "admin@gmail.com" },
                    { "9d763604-4cd3-46cb-b308-b2e48b1b8e5b", 0, "d5608029-f579-46a8-a522-67bfe901d285", "user@gmail.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEPxi4maxEITRVr1oVCQGuZq/D/VBeV6BKj9/UnSP+thtENc/ifPHFvkpQMiy6S2iXQ==", null, false, "e48e9e89-a0a6-41dd-8593-5fb46a48341c", false, "user@gmail.com" }
                });
        }
    }
}
