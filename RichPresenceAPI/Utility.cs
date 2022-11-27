using Lachee.Discord.Control;
using DiscordRPC.Logging;
using DiscordRPC;

namespace RichPresenceAPI;

public static class Utility
{
    public static DiscordRpcClient CreateDiscordRpcClient(string applicationID, int pipe = -1, ILogger? logger = null, bool autoEvents = true)
    {
        return new DiscordRpcClient(applicationID, pipe, logger, autoEvents, new UnityNamedPipe());
    }
}