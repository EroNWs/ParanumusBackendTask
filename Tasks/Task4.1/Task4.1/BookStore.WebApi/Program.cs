

using BookStore.Business.Contracts;
using BookStore.Dal.Contexts;
using BookStore.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

if (builder.Environment.IsEnvironment("Testing"))
{
 
    builder.Services.AddDbContext<BookStoreDbContext>(options =>
        options.UseInMemoryDatabase("BookStoreDb"));
}
else if (builder.Environment.IsDevelopment())
{

    builder.Services.AddDbContext<BookStoreDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ParanamusDbContext")));
}
else
{

    builder.Services.AddDbContext<BookStoreDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ParanamusDbContext")));
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

builder.Services.ConfigureAllDtoAutoMapper();

builder.Services.AddControllers(opt =>
{
    opt.CacheProfiles.Add("10mins", new CacheProfile() { Duration = 250 });
    //opt.Filters.Add(new AuthorizeFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureHttpCacheHeaders();
var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();

app.ConfigureExceptionHandler(logger);
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseResponseCaching();
app.UseHttpCacheHeaders();
//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
