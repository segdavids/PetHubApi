using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHubApi.Migrations
{
    /// <inheritdoc />
    public partial class SeededCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryId", "Name", "ShortName" },
                values: new object[] { 1, null, "Nigeria", "NG" });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "CountryId", "Description", "Name" },
                values: new object[] { 1, 1, "Rot has a big head", "rot" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Breeds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
