

using BookStore.Dal.Contexts;
using BookStore.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    // Geliþtirme ortamý için InMemory veritabaný
    builder.Services.AddDbContext<BookStoreDbContext>(options =>
        options.UseInMemoryDatabase("BookStoreDb"));
}
else
{
    // Üretim ortamý için SQL Server
    builder.Services.AddDbContext<BookStoreDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDb")));
}



// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});



builder.Services
    .AddEFCoreServices(builder.Configuration)
    .AddBusinessServices();


builder.Services.AddControllers(opt =>
{
    //opt.Filters.Add(new AuthorizeFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
