using EcommerceApp.Dtos;

namespace EcommerceApp;

public static class ProductEndpoints
{
    const string GetProductEndpointName = "GetProduct";

    // route for product rest api sample implementation for practice
    private static readonly List<ProductDto> products = [
        new (
        1,
        "Tuna",
        10.99M,
        2,
        3.99M,
        15.99M,
        new DateTime(2024, 8, 19)
    ),
    new (
        2,
        "Pasta",
        20.99M,
        1,
        4.99M,
        30.99M,
        new DateTime(2019, 2, 10)
    ),
    new (
        3,
        "Eggs",
        8.99M,
        4,
        1.99M,
        5.99M,
        new DateTime(2022, 4, 2)
    ),
];


    public static RouteGroupBuilder MapProductsEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("products")
                       .WithParameterValidation();

        // GET /products
        group.MapGet("/", () => products);

        // GET /products/1 get a product by id
        group.MapGet("/{id}", (int id) =>
        {
            ProductDto? product = products.Find(product => product.ProductId == id);

            return product is null ? Results.NotFound() : Results.Ok(product);
        })
        .WithName(GetProductEndpointName);

        // POST /products add a product to the api/database
        group.MapPost("/", (CreateProductDto newProduct) =>
        {
            ProductDto product = new(
                products.Count + 1,
                newProduct.ProductName,
                newProduct.ProductPrice,
                newProduct.ProductQuantity,
                newProduct.ProductShippingCost,
                newProduct.ProductTotalCost,
                newProduct.ProductEstimatedArrivalDate
            );
            products.Add(product);

            return Results.CreatedAtRoute(GetProductEndpointName, new { id = product.ProductId }, product);
        });


        // PUT /products update products api/database
        group.MapPut("/{id}", (int id, UpdateProductDto updatedProduct) =>
        {
            var index = products.FindIndex(product => product.ProductId == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            products[index] = new ProductDto(
                id,
                updatedProduct.ProductName,
                updatedProduct.ProductPrice,
                updatedProduct.ProductQuantity,
                updatedProduct.ProductShippingCost,
                updatedProduct.ProductTotalCost,
                updatedProduct.ProductEstimatedArrivalDate
            );

            return Results.NoContent();
        });

        // DELETE /products/1 delete a product from api/database
        group.MapDelete("/{id}", (int id) =>
        {
            products.RemoveAll(product => product.ProductId == id);

            return Results.NoContent();
        });

        return group;
    }
}
