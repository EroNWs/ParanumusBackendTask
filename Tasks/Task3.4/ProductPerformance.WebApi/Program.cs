using Microsoft.EntityFrameworkCore;
using ProductPerformance.DAL.Contexts;
using ProductPerformance.Application.Extensions;
using ProductPerformance.Infrastracture.RepoExtensions;
using NLog;
using ProductPerformance.Application.Contracts;
using ProductPerformance.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));


// Add services to the container.
builder.Services.AddDbContext<ProductPerformanceDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDb")));
builder.Services.AddServiceExtensions();
builder.Services.AddInfrastractureExtensions();
builder.Services.AddControllers(config =>
{
    config.CacheProfiles.Add("10mins", new Microsoft.AspNetCore.Mvc.CacheProfile() { Duration = 250 });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureHttpCacheHeaders();
var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExtceptionHandler(logger);
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
app.UseHttpsRedirection();

app.UseResponseCaching();
app.UseHttpCacheHeaders();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
