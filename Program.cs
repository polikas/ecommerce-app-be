using ecommerce.Models;
using EcommerceApp.Dtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext and configure the connection string
builder.Services.AddDbContext<EcommerceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure services
void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication();
    services.AddAuthorization();
    services.AddMvc();
}

ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable HTTP Strict Transport Security (HSTS)
app.UseHsts();

// Authorization middleware
app.UseAuthorization();

// Map controllers
app.MapControllers();

// route for product rest api simple implementation for practice
List<ProductDto> products = [
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

// GET /products
app.MapGet("products", () => products);

// GET /products/1 get a product by id
app.MapGet("products/{id}", (int id) => products.Find(product => product.ProductId == id));


app.Run();
