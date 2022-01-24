namespace ShopApp.Models
{
    public class Product : Entity
    {
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
        public decimal Price { get; set; }
    }
}
