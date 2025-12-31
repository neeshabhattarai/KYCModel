using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApplicationClass.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "PersonalInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PersonalInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Income",
                table: "PersonalInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NationalId",
                table: "PersonalInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "PersonalInfo");

            migrationBuilder.DropColumn(
                name: "City",
                table: "PersonalInfo");

            migrationBuilder.DropColumn(
                name: "Income",
                table: "PersonalInfo");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "PersonalInfo");
        }
    }
}
