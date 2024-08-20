using NLog;
using System;

namespace MyApp
{
    static class Logger
    {
        private readonly static NLog.Logger _logger;

        public const string LOG_DIRECTORY_LOCATION = @"..\..\Log";

        static Logger()
        {
            _logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();
        }

        internal static void LogDebug(string message)
        {
            _logger.Debug(message);
        }

        internal static void LogWarning(string message)
        {
            _logger.Warn(message);
        }

        internal static void LogError(Exception ex)
        {
            _logger.Error(ex, ex.Message);
        }

        internal static void LogError(string message)
        {
            _logger.Error(message);
        }
    }
}
