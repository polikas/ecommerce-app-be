
namespace ecommerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductShippingCost { get; set; }
        public decimal ProductTotalCost { get; set; }
        public DateTime ProductEstimatedArrivalDate { get; set; }
    }
}
