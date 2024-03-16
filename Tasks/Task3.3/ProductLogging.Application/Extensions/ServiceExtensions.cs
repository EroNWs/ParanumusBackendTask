using Microsoft.Extensions.DependencyInjection;
using ProductLogging.Application.Contracts;

namespace ProductLogging.Application.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureLoggerService(this IServiceCollection services)
 => services.AddSingleton<ILoggerService, LoggerManager>();
}
