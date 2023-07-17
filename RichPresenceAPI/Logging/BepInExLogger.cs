using BepInEx.Logging;
using DiscordRPC.Logging;
using LogLevel = DiscordRPC.Logging.LogLevel;

namespace RichPresenceAPI.Logging;

public class BepInExLogger : ILogger
{
    private readonly ManualLogSource logger;

    public BepInExLogger(ManualLogSource logger)
    {
        this.logger = logger;
    }

    public LogLevel Level { get; set; }


    public void Trace(string message, params object[] args)
    {
        if (Level > LogLevel.Trace) return;
        logger.LogInfo(string.Format(message, args));
    }

    public void Info(string message, params object[] args)
    {
        if (Level > LogLevel.Info) return;
        logger.LogInfo(string.Format(message, args));
    }

    public void Warning(string message, params object[] args)
    {
        if (Level > LogLevel.Warning) return;
        logger.LogWarning(string.Format(message, args));
    }

    public void Error(string message, params object[] args)
    {
        if (Level > LogLevel.Error) return;
        logger.LogError(string.Format(message, args));
    }
}