using A_DatabaseCodeFirst;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

class Program
{
    static async Task Main()
    {
        using (MyDatabase db = new())
        {
            Console.WriteLine("Can Connect Database: {0}", db.Database.CanConnect());
            //* Create
            // Category category = new Category()
            // {
            //     CategoryName = "Furniture",
            //     Description = "This is a furniture"
            // };
            // await db.AddAsync(category);
            // await db.SaveChangesAsync();

            //* Read
            var categories = db.Categories;
            var products = db.Products;
            Console.WriteLine("\nAll Category Name:");
            await categories.ForEachAsync(c => Console.WriteLine("\t" + c.CategoryName));
            Console.WriteLine("\nAll Products Name:");
            await products.ForEachAsync(p => Console.WriteLine("\t" + p.ProductName));
            

            //* Update
            // Product product1 = await db.Products.FindAsync(1);
            // product1.ProductName = "RadioFM";
            // await db.SaveChangesAsync();
            // Category category1 = await db.Categories.FindAsync(3);
            // category1.CategoryName = "TestMaxLengthTestMaxLengthTest";
            // await db.SaveChangesAsync();

            //* Delete
            // Category category2 = await db.Categories.FirstOrDefaultAsync(c => c.CategoryName == "Furniture");
            // db.Categories.Remove(category2);
            // await db.SaveChangesAsync();


        }
    }
}