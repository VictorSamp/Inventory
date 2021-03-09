using System.Collections.Generic;

namespace Inventory.Models
{
    public class Manufacturer
    {
        public long ManufacturerId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
