using System.Runtime.InteropServices;
using DiscordRPC;
using DiscordRPC.Logging;
using Lachee.Discord.Control;

namespace RichPresenceAPI;

public static class Utility
{
    public static DiscordRpcClient CreateDiscordRpcClient(string applicationID, int pipe = -1, ILogger? logger = null,
        bool autoEvents = true)
    {
        return new DiscordRpcClient(applicationID, pipe, logger, autoEvents, new UnityNamedPipe());
    }

    public static string GetLibraryExtension()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) return "dll";

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) return "so";

        return RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "dylib" : "";
    }
}