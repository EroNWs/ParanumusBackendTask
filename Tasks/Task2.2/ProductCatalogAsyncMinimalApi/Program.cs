using Microsoft.AspNetCore.Mvc;
using ProductCatalogAsyncMinimalApi.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var products = new List<Product>();

// Adding Product
app.MapPost("/products", async ([FromBody] Product product) =>
{
    await Task.Run(() => products.Add(product));
    return Results.Created($"/products/{product.Id}", product);
});

// Listing Products
app.MapGet("/products", async () =>
{
    return await Task.FromResult(Results.Ok(products));
});

// Getting One Product
app.MapGet("/products/{id}", async (int id) =>
{
    var product = await Task.Run(() => products.FirstOrDefault(p => p.Id == id));
    return product != null ? Results.Ok(product) : Results.NotFound();
});

// Updating a Product
app.MapPut("/products/{id}", async (int id, [FromBody] Product updatedProduct) =>
{
    var index = await Task.Run(() => products.FindIndex(p => p.Id == id));
    if (index == -1)
    {
        return Results.NotFound();
    }
    products[index] = updatedProduct;
    return Results.NoContent();
});

// Deleting a Product
app.MapDelete("/products/{id}", async (int id) =>
{
    var index = await Task.Run(() => products.FindIndex(p => p.Id == id));
    if (index == -1)
    {
        return Results.NotFound();
    }
    await Task.Run(() => products.RemoveAt(index));
    return Results.NoContent();
});

app.Run();
