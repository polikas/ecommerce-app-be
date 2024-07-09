using System.ComponentModel.DataAnnotations;
namespace EcommerceApp.Dtos;

public record class CreateOrderDto(
    [Required][Range(0, double.MaxValue)] decimal ShippingCost,
    [Required][Range(0, double.MaxValue)] decimal TotalAmount,
    [Required] DateTime EstimatedArrivalDate,
    [Required][StringLength(100)] string ShippingAddress,
    [Required][StringLength(50)] string FirstName,
    [Required][StringLength(50)] string LastName,
    [Required][EmailAddress] string Email,
    [Required][Phone] string PhoneNumber,
    [Required][StringLength(50)] string Country,
    [Required][StringLength(50)] string City,
    [Required][StringLength(10)] string PostalCode,
    string? ShippingComments,
    List<OrderDetailDto> OrderDetails
);
