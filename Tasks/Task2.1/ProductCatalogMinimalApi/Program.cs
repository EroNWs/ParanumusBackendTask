using ProductCatalogMinimalApi.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var products = new List<Product>();

// Adding Product
app.MapPost("/products", (Product product) =>
{
    products.Add(product);
    return Results.Created($"/products/{product.Id}", product);
});

//Listing Products
app.MapGet("/products", () => products);

//Getting One Product
app.MapGet("/products/{id}", (int id) =>
{
    var product = products.FirstOrDefault(p => p.Id == id);
    return product != null ? Results.Ok(product) : Results.NotFound();
});

//Updating a Product
app.MapPut("/products/{id}", (int id, Product updatedProduct) =>
{
    var index = products.FindIndex(p => p.Id == id);
    if (index == -1)
    {
        return Results.NotFound();
    }
    products[index] = updatedProduct;
    return Results.NoContent();
});

//Deleting a Product
app.MapDelete("/products/{id}", (int id) =>
{
    var index = products.FindIndex(p => p.Id == id);
    if (index == -1)
    {
        return Results.NotFound();
    }
    products.RemoveAt(index);
    return Results.NoContent();

});

app.Run();
