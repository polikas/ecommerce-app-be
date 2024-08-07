﻿using EcommerceApp.Data;
using EcommerceApp.Dtos;
using EcommerceApp.Entities;
using EcommerceApp.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Endpoints;

public static class OrderEndPoints
{

    const string GetOrderEndpointName = "GetOrder";
    public static RouteGroupBuilder MapOrdersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("orders")
                       .WithParameterValidation();


        group.MapGet("/{id}", (int id, EcommerceDbContext dbContext) =>
        {
            Order? order = dbContext.Orders.Find(id);

            return order is null ? Results.NotFound() : Results.Ok(order);
        })
        .WithName(GetOrderEndpointName);

        // POST /orders add an order to the database
        group.MapPost("/", (CreateOrderDto newOrder, EcommerceDbContext dbContext) =>
        {
            Order order = newOrder.ToEntity(dbContext);

            dbContext.Orders.Add(order);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetOrderEndpointName, new { id = order.OrderId }, order.ToDto());
        });

        // Need to develop Delete endpoint/ PUT and maybe get / ?

        return group;
    }
}
