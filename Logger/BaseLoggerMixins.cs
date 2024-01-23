using System;

namespace Logger;

public static class BaseLoggerMixins
{

    public static void Error(this BaseLogger? logger, string message, params object[] args) 
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger cannot be null.");
        }

        else
        {
            string errorMessage = string.Format(null, message, args);
            logger.Log(LogLevel.Error, errorMessage);
        }
    }

    public static void Warning(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger cannot be null.");
        }

        else
        {
            string warningMessage = string.Format(null, message, args);
            logger.Log(LogLevel.Warning, warningMessage);
        }
    }

    public static void Information(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger), "Logger cannot be null.");
        }

        else
        {
            string informationMessage = string.Format(null, message, args);
            logger.Log(LogLevel.Information, informationMessage);
        }
    }

    public static void Debug(this BaseLogger? logger, string message, params object[] args)
    {
        if (logger == null)
        {
            throw new ArgumentNullException(nameof(logger),"Logger cannot be null.");
        }

        else
        {
            string debugMessage = string.Format(null, message, args);
            logger.Log(LogLevel.Debug, debugMessage);
        }
    }

}
