using System.Diagnostics;
using A_Database;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main()
    {
        Stopwatch sw = new Stopwatch();
        using (Northwind db = new Northwind())
        {
            //* simple get category name
            // List<Category> categories = db.Categories.Include(c => c.Products).ToList();
            // foreach(var c in categories)
            // {
            //     // Console.WriteLine($"Id: {c.CategoryId}\nName: {c.CategoryName}\n");
            //     Console.WriteLine(c.CategoryName);
            //     Console.WriteLine(c.Products.Count);
            //     foreach(var p in c.Products)
            //     {
            //         Console.WriteLine("\t" + p.ProductName);
            //     }

            // }

            //* foreach async
            // var categories = db.Categories;
            // sw.Start();
            // categories.ForEachAsync(c => Console.WriteLine(c.CategoryName));
            // sw.Stop();
            // Console.WriteLine(sw.Elapsed);
            // sw.Start();
            // foreach(var c in categories)
            // {
            //     Console.WriteLine(c.CategoryName);
            // }
            // sw.Stop();
            // Console.WriteLine(sw.Elapsed);

            //* product where unit price > 10
            // var products = db.products.Where(p => p.UnitPrice > 10);
            // foreach( var p in products)
            // {
            //     Console.WriteLine("\t" + p.ProductName + " price " + p.UnitPrice);
            // }

            //* READ
            // Product? product = await db.products.FirstOrDefaultAsync(p => p.UnitPrice > 10);
            // IQueryable<Product> products = db.Products.Where(p => p.UnitPrice > 10);
            // foreach (var p in products)
            // {
            //     Console.WriteLine("\t" + p.ProductName + " price " + p.UnitPrice);
            // }

            //* CUD --> db.SaveChange()
            //* Create
            // Category category = new Category()
            // {
            //     // CategoryId = 9;,                 //! Must unique, if not define will automatically assign from the last id
            //     CategoryName = "Electronic",        //! Must assign, coz NOT NULL, will error if not assign
            //     Description = "Ini Electronic"
            // };

            // await db.Categories.AddAsync(category);
            // await db.SaveChangesAsync();

            //* Update
            // Category category1 = await db.Categories.FindAsync(9);
            // Category category2 = await db.Categories.FirstOrDefaultAsync(c => c.CategoryId == 9);
            // category1.CategoryName = "Elektroniksss";
            // await db.SaveChangesAsync();

            //* Delete
            Category category3 = await db.Categories.FindAsync(9);
            db.Categories.Remove(category3);
            db.SaveChangesAsync();



        }
    }
}
