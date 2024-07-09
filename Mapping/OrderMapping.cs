using EcommerceApp.Data;
using EcommerceApp.Dtos;
using EcommerceApp.Entities;

namespace EcommerceApp.Mapping;

public static class OrderMapping
{
    public static Order ToEntity(this CreateOrderDto orderDto, EcommerceDbContext dbContext)
    {
        var order = new Order
        {
            OrderDate = DateTime.Now,
            ShippingCost = orderDto.ShippingCost,
            TotalAmount = orderDto.TotalAmount,
            EstimatedArrivalDate = orderDto.EstimatedArrivalDate,
            ShippingAddress = orderDto.ShippingAddress,
            FirstName = orderDto.FirstName,
            LastName = orderDto.LastName,
            Email = orderDto.Email,
            PhoneNumber = orderDto.PhoneNumber,
            Country = orderDto.Country,
            City = orderDto.City,
            PostalCode = orderDto.PostalCode,
            ShippingComments = orderDto.ShippingComments,
            OrderDetails = new List<OrderDetail>()
        };

        order.OrderDetails = orderDto.OrderDetails.Select(od =>
        {
            var product = dbContext.Products.FirstOrDefault(p => p.ProductId == od.ProductId);

            return new OrderDetail
            {
                ProductId = od.ProductId,
                ProductName = od.ProductName,
                ProductPrice = od.ProductPrice,
                Quantity = od.Quantity,
                Order = order,
                Product = product!
            };
        }).ToList();

        return order;
    }

    public static OrderSummaryDto ToDto(this Order order)
    {
        return new OrderSummaryDto(
            order.OrderDate,
            order.ShippingCost,
            order.TotalAmount,
            order.EstimatedArrivalDate,
            order.ShippingAddress,
            order.FirstName,
            order.LastName,
            order.Email,
            order.PhoneNumber,
            order.Country,
            order.City,
            order.PostalCode,
            order.ShippingComments,
            order.OrderDetails.Select(od => new OrderDetailDto(
                od.OrderDetailId,
                od.OrderId,
                od.ProductId,
                od.ProductName,
                od.ProductPrice,
                od.Quantity
            )).ToList()
        );
    }
}
