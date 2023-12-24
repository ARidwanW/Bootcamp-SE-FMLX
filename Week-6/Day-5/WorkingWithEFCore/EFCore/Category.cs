using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore
{
	public class Category
	{
		public int CategoryId { get; set; } //Primary Key
		[Required]
		public string? CategoryName { get; set; }
		[Column(TypeName = "NTEXT")]
		public string? Description { get; set; }
		
		public virtual ICollection<Product> Products { get; set; }
		public Category() 
		{
			Products = new HashSet<Product>();
		}
	}
}