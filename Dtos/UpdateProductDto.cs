namespace EcommerceApp.Dtos;

public record class UpdateProductDto(
    string ProductName,
    decimal ProductPrice,
    int ProductQuantity,
    decimal ProductShippingCost,
    decimal ProductTotalCost,
    DateTime ProductEstimatedArrivalDate
);