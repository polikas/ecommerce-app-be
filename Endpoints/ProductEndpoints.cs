using EcommerceApp.Data;
using EcommerceApp.Dtos;
using EcommerceApp.Mapping;
using EcommerceApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Endpoints;

public static class ProductEndpoints
{
    const string GetProductEndpointName = "GetProduct";


    public static RouteGroupBuilder MapProductsEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("products")
                       .WithParameterValidation();

        // GET /products
        group.MapGet("/", (EcommerceDbContext dbContext) =>
        {
            var products = dbContext.Products
                     .Select(product => product.ToDto())
                     .AsNoTracking()
                     .ToList();
            return Results.Ok(products);
        });

        // GET /products/1 get a product by id
        group.MapGet("/{id}", (int id, EcommerceDbContext dbContext) =>
        {
            Product? product = dbContext.Products.Find(id);

            return product is null ? Results.NotFound() : Results.Ok(product);
        })
        .WithName(GetProductEndpointName);

        // POST /products add a product to the api/database
        group.MapPost("/", (CreateProductDto newProduct, EcommerceDbContext dbContext) =>
        {
            //create entity
            Product product = newProduct.ToEntity();

            //save entity to the db
            dbContext.Products.Add(product);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GetProductEndpointName, new { id = product.ProductId }, product.ToDto());
        });


        // PUT /products update products api/database
        group.MapPut("/{id}", (int id, UpdateProductDto updatedProduct, EcommerceDbContext dbContext) =>
        {
            var existingProduct = dbContext.Products.Find(id);

            if (existingProduct is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingProduct)
                    .CurrentValues
                    .SetValues(updatedProduct.ToEntity(id));

            dbContext.SaveChanges();

            return Results.NoContent();
        });

        // // DELETE /products/1 delete a product from api/database
        // group.MapDelete("/{id}", (int id) =>
        // {
        //     products.RemoveAll(product => product.ProductId == id);

        //     return Results.NoContent();
        // });

        return group;
    }
}
