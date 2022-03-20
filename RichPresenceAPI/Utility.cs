using DiscordRPC.Logging;
using DiscordRPC.Unity;
using DiscordRPC;

namespace RichPresenceAPI
{
    public static class Utility
    {
        public static DiscordRpcClient createClient(string applicationID, int pipe = -1, ILogger logger = null, bool autoEvents = true) {
            return new DiscordRpcClient(applicationID, pipe, logger, autoEvents, new UnityNamedPipe());
        }
    }
}