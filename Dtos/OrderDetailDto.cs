namespace EcommerceApp.Dtos;

public record class OrderDetailDto(
    int ProductId,
    string ProductName,
    decimal ProductPrice,
    int Quantity
);



