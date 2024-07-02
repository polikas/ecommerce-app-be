namespace EcommerceApp.Dtos;

public record class ProductDto(
    int ProductId,
    string ProductName,
    decimal ProductPrice,
    int ProductQuantity,
    decimal ProductShippingCost,
    decimal ProductTotalCost,
    DateTime ProductEstimatedArrivalDate
);