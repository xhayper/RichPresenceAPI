# RichPresenceAPI

'discord-rpc-csharp' for Unity BepInEx plugin

## Why use this instead of 'discord-rpc-csharp' directly?

Unity broke the '[Named Pipe Client Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.pipes.namedpipeclientstream)' that 'discord-rpc-charp' use,  so 'discord-rpc-charp' recommended us to install a alternative called '[NativeNamedPipe](https://github.com/Lachee/unity-named-pipes/tree/1d1abc0bce88c89ba728907f2d338e65c72b74ef/UnityNamedPipe.Native)', which is really hard to install via BepInEx. This plugin install it and load the native lib for you so you don't have to be in pain trying to get the native lib to work (trust me, i spent hours of research).

## Why Unity version '2019.4.24'?

This was originally planned to be used for '[Inscryption](https://store.steampowered.com/app/1092790/Inscryption)' only, which runs on 2019.4.24, so i stick with it, it should be complatible with every version that discord-rpc-csharp support.

## Example Usage

```cs
using RichPresenceAPI.Logging;
using DiscordRPC.Logging;
using RichPresenceAPI;
using DiscordRPC;
using BepInEx;

namespace ExamplePlugin;

[BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
[BepInDependency("io.github.xhayper.RichPresenceAPI")]
public class Plugin : BaseUnityPlugin
{
    private DiscordRpcClient client;

    private void Awake()
    {
        client = RichPresenceAPI.Utility.CreateDiscordRpcClient("123456789054321");

        //Set the logger
        client.Logger = new BepInExLogger(Logger)
        {
            Level = LogLevel.Trace
        };

        //Connect to the RPC
        client.Initialize();

        //Set the rich presence
        //Call this as many times as you want and anywhere in your code.
        client.SetPresence(new RichPresence()
        {
	        Details = "Example Project",
	        State = "csharp example",
	        Assets = new Assets()
	        {
		        LargeImageKey = "image_large",
		        LargeImageText = "Lachee's Discord IPC Library",
		        SmallImageKey = "image_small"
	        }
        });
    }

    private void OnDestroy()
    {
        if (client != null)
            client.Dispose();
    }
}
```

## See also

-   [discord-rpc-charp's README](https://github.com/Lachee/discord-rpc-csharp)
