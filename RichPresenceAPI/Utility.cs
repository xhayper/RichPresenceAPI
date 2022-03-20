using DiscordRPC.Logging;
using DiscordRPC.Unity;
using DiscordRPC;
using System;

namespace RichPresenceAPI
{
    public static class Utility
    {
        public static DiscordRpcClient createDiscordRpcClient(string applicationID, int pipe = -1, ILogger logger = null, bool autoEvents = true) {
            return new DiscordRpcClient(applicationID, pipe, logger, autoEvents, new UnityNamedPipe());
        }

        [Obsolete("Use createDiscordRpcClient instead")]
        public static DiscordRpcClient createClient(string applicationID, int pipe = -1, ILogger logger = null, bool autoEvents = true) {
            return createDiscordRpcClient(applicationID, pipe, logger, autoEvents);
        }
    }
}