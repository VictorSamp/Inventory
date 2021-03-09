namespace Inventory.Models
{
    public class Product
    {
        public long? ProductId { get; set; }
        public string Name { get; set; }
        public long? CategoryId { get; set; }
        public long? ManufacturerId { get; set; }
        public Category Category { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }
}
