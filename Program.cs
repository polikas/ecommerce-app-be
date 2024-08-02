using EcommerceApp.Data;
using EcommerceApp.Endpoints;
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

app.MapOrdersEndpoints();

app.MapProductsEndpoints();

app.MigrateDb();

app.Run();

//  add unitx or other tool (maybe Mock) to practice unit testing
