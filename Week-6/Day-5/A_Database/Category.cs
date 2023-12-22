using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;

namespace A_Database;

public class Category
{
    [Key]                       //* Menandakan primary key
    public int CategoryId { get; set; }
    [Required]                  //* Menandakan Not Null
    [StringLength(15)]          //* Menandakan batas char string
    public string CategoryName { get; set; } = null!;
    [Column(TypeName = "ntex")]
    public string Description { get; set; }

    public ICollection<Product> Products { get; set; }

    public Category()
    {
        Products = new HashSet<Product>();
    }
    

}
