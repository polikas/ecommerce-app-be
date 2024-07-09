
namespace EcommerceApp.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime EstimatedArrivalDate { get; set; }
        public required string ShippingAddress { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Country { get; set; }
        public required string City { get; set; }
        public required string PostalCode { get; set; }
        public string? ShippingComments { get; set; }

        // Navigation property
        public required ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
