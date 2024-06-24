
namespace ecommerce.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderShippingCost { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public DateTime OrderEstimatedArrivalDate { get; set; }
        public required string OrderShippingAddress { get; set; }
        public required string OrderFirstName { get; set; }
        public required string OrderLastName { get; set; }
        public required string OrderEmail { get; set; }
        public required string OrderPhoneNumber { get; set; }
        public required string OrderCountry { get; set; }
        public required string OrderCity { get; set; }
        public required string OrderPostalCode { get; set; }
        public string? OrderShippingComments { get; set; }

        // Navigation property
        public required ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
