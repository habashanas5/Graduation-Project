namespace GraduationProject.Models.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Product? Product { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get { return Price * Quantity; } }
        public DateTime CreatedDate { get; set; }
        public string? UserId { get; set; }

    }
}
