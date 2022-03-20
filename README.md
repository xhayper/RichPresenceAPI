# RichPresenceAPI

'discord-rpc-csharp' for Unity BepInEx plugin

## Why use this instead of 'discord-rpc-csharp'?

- Unity broke the '[Named Pipe Client Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.pipes.namedpipeclientstream)' that '[discord-rpc-charp](https://github.com/Lachee/discord-rpc-csharp)' use, So we have to use the "NativeNamedPipe" that '[discord-rpc-charp](https://github.com/Lachee/discord-rpc-csharp) told us, But it's a pain to do it, This plugin simplify all of those thing.

## Why Unity version '2019.4.24'?

- This was originally planned to be used for '[Inscryption](https://store.steampowered.com/app/1092790/Inscryption)', Hence the '2019.4.2'

## Example Usage

```cs
using RichPresenceAPI.Logging;
using DiscordRPC.Logging;
using RichPresenceAPI;
using DiscordRPC;
using BepInEx;

namespace ExamplePlugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("io.github.xhayper.RichPresenceAPI")]
    public class Plugin : BaseUnityPlugin
    {
        private DiscordRpcClient client;

        private void Awake()
        {
            client = RichPresenceAPI.Utility.createClient(my_client_id);

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
            client.Dispose();
        }
    }
}
```

## See also
- [discord-rpc-charp's README](https://github.com/Lachee/discord-rpc-csharp)