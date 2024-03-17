using Microsoft.EntityFrameworkCore;
using NLog;
using ProductLogging.Infrastracture.Extensions;
using ProductLogging.Application.Extensions;
using ProductLogging.DAL;
using ProductLogging.Application.Contracts;
using ProductLogging.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.
builder.Services.AddDbContext<ProductLoggingDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDb")));
builder.Services.AddServiceExtensions();
builder.Services.AddInfrastractureExtensions();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
