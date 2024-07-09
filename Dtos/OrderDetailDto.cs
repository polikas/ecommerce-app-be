namespace EcommerceApp.Dtos;

public record class OrderDetailDto(
    int OrderDetailId,
    int OrderId,
    int ProductId,
    string ProductName,
    decimal ProductPrice,
    int Quantity
);



