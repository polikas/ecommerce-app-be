using EcommerceApp.Dtos;
using EcommerceApp.Entities;

namespace EcommerceApp.Mapping;

public static class ProductMapping
{
    //create entity
    public static Product ToEntity(this CreateProductDto product)
    {
        return new Product()
        {
            ProductName = product.ProductName,
            ProductPrice = product.ProductPrice,
            ProductQuantity = product.ProductQuantity,
            ProductShippingCost = product.ProductShippingCost,
            ProductTotalCost = product.ProductTotalCost,
            ProductEstimatedArrivalDate = product.ProductEstimatedArrivalDate
        };
    }

    public static Product ToEntity(this UpdateProductDto product, int id)
    {
        return new Product()
        {
            ProductId = id,
            ProductName = product.ProductName,
            ProductPrice = product.ProductPrice,
            ProductQuantity = product.ProductQuantity,
            ProductShippingCost = product.ProductShippingCost,
            ProductTotalCost = product.ProductTotalCost,
            ProductEstimatedArrivalDate = product.ProductEstimatedArrivalDate
        };
    }


    //create  DTO data transfer object to send back to the client
    public static ProductDto ToDto(this Product product)
    {
        return new(
            product.ProductId,
            product.ProductName,
            product.ProductPrice,
            product.ProductQuantity,
            product.ProductShippingCost,
            product.ProductTotalCost,
            product.ProductEstimatedArrivalDate
        );
    }
}
