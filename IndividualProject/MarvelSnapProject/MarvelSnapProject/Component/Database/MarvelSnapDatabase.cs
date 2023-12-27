using MarvelSnapProject.Component.Card;
using MarvelSnapProject.Component.Location;
using MarvelSnapProject.Enum;
using Microsoft.EntityFrameworkCore;

namespace MarvelSnapProject.Component.Database;

public class MarvelSnapDatabase : DbContext
{
    private DbSet<Card> Cards { get; set; }
    private DbSet<Location> Locations { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=./Component/Database/MarvelSnapDatabase.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(card =>
        {
            card.HasKey(c => c.CardId);
            card.Property(c => c.CardName).IsRequired().HasMaxLength(30);
            card.Property(c => c.Description).HasMaxLength(100);
            card.Property(c => c.IsOnGoing);
            card.Property(c => c.IsOnReveal);
        });

        modelBuilder.Entity<Location>(location => 
        {
            location.HasKey(l => l.LocationId);
            location.Property(l => l.LocationName).IsRequired().HasMaxLength(30);
            location.Property(l => l.Description).HasMaxLength(100);
            location.Property(l => l.IsOnGoing);
            location.Property(l => l.IsOnReveal);
        });

        //* Seeding
        modelBuilder.Entity<Card>().HasData(
            new Card()
            {
                CardId = 1,
                CardName = "Abomination",
                Description = "Foolish rabble! You are beneath me!",
                IsOnGoing = false,
                IsOnReveal = false
            },
            new Card()
            {
                CardId = 2,
                CardName = "Cyclops",
                Description = "Lets move, X-men.",
                IsOnGoing = false,
                IsOnReveal = false
            },
            new Card()
            {
                CardId = 3,
                CardName = "Hawkeye",
                Description = "On Reveal: if you play a card at this location next turn, +3 power.",
                IsOnGoing = false,
                IsOnReveal = true
            },
            new Card()
            {
                CardId = 4,
                CardName = "Hulk",
                Description = "HULK SMASH!",
                IsOnGoing = false,
                IsOnReveal = false
            },
            new Card()
            {
                CardId = 5,
                CardName = "Iron Man",
                Description = "On Going: Your total Power is doubled at this location.",
                IsOnGoing = true,
                IsOnReveal = false
            },
            new Card()
            {
                CardId = 7,
                CardName = "Medusa",
                Description = "On Reveal: if this at the middle location, +3 Power.",
                IsOnGoing = false,
                IsOnReveal = true
            },
            new Card()
            {
                CardId = 10,
                CardName = "Quick Silver",
                Description = "Starts in your opening hand",
                IsOnGoing = false,
                IsOnReveal = false
            },
            new Card()
            {
                CardId = 15,
                CardName = "Thing",
                Description = "It's clobberin' time!",
                IsOnGoing = false,
                IsOnReveal = false
            }
        );

        modelBuilder.Entity<Location>().HasData(
            new Location()
            {
                LocationId = 6,
                LocationName = "Flooded",
                Description = "Cards can't be played here.",
                IsOnGoing = false,
                IsOnReveal = false
            },
            new Location()
            {
                LocationId = 7,
                LocationName = "K'un-Lun",
                Description = "When a card moves here, give it +2 Power.",
                IsOnGoing = true,
                IsOnReveal = false
            },
            new Location()
            {
                LocationId = 8,
                LocationName = "Negative Zone",
                Description = "Cards here have -3 Power.",
                IsOnGoing = true,
                IsOnReveal = false
            },
            new Location()
            {
                LocationId = 9,
                LocationName = "Ruins",
                Description = "-",
                IsOnGoing = false,
                IsOnReveal = false
            }
        );
    }

}
