using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Dtos;

public record class CreateProductDto(
    [Required][StringLength(100)] string ProductName,
    [Required][Range(1, 200)] decimal ProductPrice,
    [Required] int ProductQuantity,
    [Required][Range(1, 200)] decimal ProductShippingCost,
    [Required][Range(1, 200)] decimal ProductTotalCost,
    [Required] DateTime ProductEstimatedArrivalDate
);
