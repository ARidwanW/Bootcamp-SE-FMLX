
using System.ComponentModel.DataAnnotations;
using EFCore;
using Microsoft.EntityFrameworkCore;

namespace EFDatabase;

public class Northwind : DbContext
{
	public DbSet<Category>? categories;
	public DbSet<Product>? product;
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		string path = Path.Combine( Environment.CurrentDirectory, "Northwind.db");
		string connection = ($"Data Source={path}");
		Console.WriteLine($"Connection: {connection}");
		optionsBuilder.UseSqlite(connection);
	}
}