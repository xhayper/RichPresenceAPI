using DiscordRPC.Logging;
using System;

namespace RichPresenceAPI.Logging
{
    public class BepInExLogger : ILogger
    {
        private BepInEx.Logging.ManualLogSource logger;

        public BepInExLogger(BepInEx.Logging.ManualLogSource logger)
        {
            this.logger = logger;
        }

        public LogLevel Level { get; set; }

        public void Trace(string message, params object[] args)
        {
            if (Level > LogLevel.Trace) return;
            logger.LogInfo(String.Format(message, args));
        }

        public void Info(string message, params object[] args)
        {
            if (Level > LogLevel.Info) return;
            logger.LogInfo(String.Format(message, args));
        }

        public void Warning(string message, params object[] args)
        {
            if (Level > LogLevel.Warning) return;
            logger.LogWarning(String.Format(message, args));
        }

        public void Error(string message, params object[] args)
        {
            if (Level > LogLevel.Error) return;
            logger.LogError(String.Format(message, args));
        }
    }
}
