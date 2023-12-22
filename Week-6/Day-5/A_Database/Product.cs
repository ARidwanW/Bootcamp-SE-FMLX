using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A_Database;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    [StringLength(40)]
    public string ProductName { get; set; } = null!;
    [ForeignKey("Supplier")]
    public int SupplierId { get; set; }
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    [StringLength(20)]
    public string QuantityPerUnit { get; set; }
    [Column(TypeName = "money")]
    public int UnitPrice { get; set; }

}
