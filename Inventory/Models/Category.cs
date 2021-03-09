using System.Collections.Generic;

namespace Inventory.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
