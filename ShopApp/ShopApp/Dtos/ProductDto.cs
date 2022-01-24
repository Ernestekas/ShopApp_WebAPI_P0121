namespace ShopApp.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public decimal Price { get; set; }
        
    }
}
