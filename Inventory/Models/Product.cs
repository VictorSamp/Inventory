using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Product
    {
        [DisplayName("Id")]
        public long? ProductId { get; set; }

        [StringLength(100, ErrorMessage = "The product name must be at least 10 characters long", MinimumLength = 10)]
        [Required(ErrorMessage = "Enter the product name")]
        public string Name { get; set; }

        [DisplayName("Category")]
        public long? CategoryId { get; set; }

        [DisplayName("Manufacturer")]
        public long? ManufacturerId { get; set; }

        public Category Category { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
