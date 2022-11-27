using System.Runtime.InteropServices;
using BepInEx;

namespace RichPresenceAPI;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private IntPtr hModule;

    private void OnEnable()
    {
        LoadDll();
    }

    private void OnDisable()
    {
        UnloadDll();
    }

    private void LoadDll()
    {
        var dllFolder = Path.Combine(Path.GetDirectoryName(Info.Location), "Assets", "lib", "x86_64");
        var dllPath = Path.Combine(dllFolder, RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "NativeNamedPipe.dll" : "NativeNamedPipe.so");

        hModule = Native.Kernel32.LoadLibrary(dllPath);

        if (hModule == IntPtr.Zero) throw new Exception(String.Format("Failed to load \"{0}\" (ErrorCode: {1})", dllPath, Marshal.GetLastWin32Error()));
        else Logger.LogInfo("Native DLL loaded successfully, Have fun! :)");
    }

    private void UnloadDll()
    {
        Logger.LogInfo("Freeing Native DLL...");
        Native.Kernel32.FreeLibrary(hModule);
    }
}
