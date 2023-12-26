using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace A_DatabaseCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class Testmaxlengthproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 3, "TestMaxLengthTestMaxLengthTestMaxLengthTestMaxLengthTestMaxLengthTestMaxLength", "This is a Fruit." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
