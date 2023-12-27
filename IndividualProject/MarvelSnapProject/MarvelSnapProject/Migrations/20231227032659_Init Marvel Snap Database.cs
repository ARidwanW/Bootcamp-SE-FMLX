using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarvelSnapProject.Migrations
{
    /// <inheritdoc />
    public partial class InitMarvelSnapDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Ability = table.Column<int>(type: "INTEGER", nullable: false),
                    IsOnGoing = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOnReveal = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocationName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Ability = table.Column<int>(type: "INTEGER", nullable: false),
                    IsOnGoing = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOnReveal = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "CardId", "Ability", "CardName", "Description", "IsOnGoing", "IsOnReveal" },
                values: new object[,]
                {
                    { 1, 0, "Abomination", "Foolish rabble! You are beneath me!", false, false },
                    { 2, 0, "Cyclops", "Lets move, X-men.", false, false },
                    { 3, 0, "Hawkeye", "On Reveal: if you play a card at this location next turn, +3 power.", false, true },
                    { 4, 0, "Hulk", "HULK SMASH!", false, false },
                    { 5, 0, "Iron Man", "On Going: Your total Power is doubled at this location.", true, false },
                    { 7, 0, "Medusa", "On Reveal: if this at the middle location, +3 Power.", false, true },
                    { 10, 0, "Quick Silver", "Starts in your opening hand", false, false },
                    { 15, 0, "Thing", "It's clobberin' time!", false, false }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Ability", "Description", "IsOnGoing", "IsOnReveal", "LocationName" },
                values: new object[,]
                {
                    { 6, 0, "Cards can't be played here.", false, false, "Flooded" },
                    { 7, 0, "When a card moves here, give it +2 Power.", true, false, "K'un-Lun" },
                    { 8, 0, "Cards here have -3 Power.", true, false, "Negative Zone" },
                    { 9, 0, "-", false, false, "Ruins" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
