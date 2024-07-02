namespace EcommerceApp.Dtos;

public record class CreateProductDto(
    string ProductName,
    decimal ProductPrice,
    int ProductQuantity,
    decimal ProductShippingCost,
    decimal ProductTotalCost,
    DateTime ProductEstimatedArrivalDate
);
