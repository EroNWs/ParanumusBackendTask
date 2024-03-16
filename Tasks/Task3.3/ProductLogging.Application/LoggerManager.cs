using NLog;
using ProductLogging.Application.Contracts;

namespace ProductLogging.Application;

public class LoggerManager : ILoggerService
{
    private static ILogger logger;
    public void LogDebug(string message) =>logger.Debug(message);

    public void LogError(string message) => logger.Error(message);

    public void LogInfo(string message)=>logger.Info(message);

    public void LogWarning(string message) => logger.Warn(message);


}
