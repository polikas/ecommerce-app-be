namespace EcommerceApp.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public required Order Order { get; set; }
        public required Product Product { get; set; }
    }
}
