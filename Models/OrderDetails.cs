

namespace ecommerce.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderDetailQuantity { get; set; }

        // Navigation properties
        public required Order Order { get; set; }
        public required Product Product { get; set; }
    }
}
