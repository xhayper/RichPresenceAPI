using DiscordRPC.Logging;
using DiscordRPC.Unity;
using DiscordRPC;
using System;

namespace RichPresenceAPI
{
    public static class Utility
    {
        public static DiscordRpcClient CreateDiscordRpcClient(string applicationID, int pipe = -1, ILogger logger = null, bool autoEvents = true) {
            return new DiscordRpcClient(applicationID, pipe, logger, autoEvents, new UnityNamedPipe());
        }

        [Obsolete("Use CreateDiscordRpcClient instead")]
        public static DiscordRpcClient createClient(string applicationID, int pipe = -1, ILogger logger = null, bool autoEvents = true) {
            return CreateDiscordRpcClient(applicationID, pipe, logger, autoEvents);
        }
    }
}