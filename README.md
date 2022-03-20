# RichPresenceAPI

'discord-rpc-csharp' for Unity BepInEx plugin

## Why use this instead of 'discord-rpc-csharp' directly?

- Unity broke the '[Named Pipe Client Stream](https://docs.microsoft.com/en-us/dotnet/api/system.io.pipes.namedpipeclientstream)' that '[discord-rpc-charp](https://github.com/Lachee/discord-rpc-csharp)' use, '[discord-rpc-charp](https://github.com/Lachee/discord-rpc-csharp)' recommended us to install a alternative called '[NativeNamedPipe](https://github.com/Lachee/unity-named-pipes/tree/master/UnityNamedPipe.Native)' which is a pain in the ass to install, So this plugin simplify it.

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
            client = RichPresenceAPI.Utility.createDiscordRpcClient(my_client_id);

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

## Compile process
- First, you need to re-compile the '[NativeNamedPipe](https://github.com/Lachee/unity-named-pipes/tree/master/UnityNamedPipe.Native)' in 'amd64_x86', because the version that 'discord-rpc-csharp' provied with is 'x86_amd64', then, put the compiled DLL in the same folder as 'RichPresenceAPI.dll'.
- You need to download [discord-rpc-charp](https://github.com/Lachee/discord-rpc-csharp)'s DLL, and [Newtonsoft.Json](https://www.newtonsoft.com/json)'s DLL, and put it in the same folder as 'RichPresenceAPI.dll'.

## See also
- [discord-rpc-charp's README](https://github.com/Lachee/discord-rpc-csharp)