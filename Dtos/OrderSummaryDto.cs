namespace EcommerceApp.Dtos;

public record class OrderSummaryDto(
    DateTime OrderDate,
    decimal ShippingCost,
    decimal TotalAmount,
    DateTime EstimatedArrivalDate,
    string ShippingAddress,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Country,
    string City,
    string PostalCode,
    string? ShippingComments,
    List<OrderDetailDto> OrderDetails
);

