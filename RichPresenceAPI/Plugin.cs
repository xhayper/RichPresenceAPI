using System.Runtime.InteropServices;
using BepInEx;
using RichPresenceAPI.Native;

namespace RichPresenceAPI;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private IntPtr? _handle;

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
        var libPrefix = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "" : "lib";
        var libFolder = Path.Combine(Path.GetDirectoryName(Info.Location) ?? "", "Assets", "lib", "x86_64");
        var libPath = Path.Combine(libFolder, $"{libPrefix}NativeNamedPipe.{Utility.GetLibraryExtension()}");

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            _handle = Kernel32.LoadLibrary(libPath);
        else
            _handle = libdl.dlopen(libPath,
                (int)libdl.OPEN_FLAGS.RTLD_LAZY);

        if (_handle == IntPtr.Zero)
            throw new Exception($"Failed to load \"{libPath}\" (ErrorCode: {Marshal.GetLastWin32Error()})");

        Logger.LogInfo($"Native library loaded successfully\nLoaded library: {libPath}\nHandle: {_handle.Value.ToInt64()}\n Have fun! :)");
    }

    private void UnloadDll()
    {
        if (!_handle.HasValue)
            return;

        Logger.LogInfo("Freeing native library...");

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            Kernel32.FreeLibrary(_handle.Value);
        else
            libdl.dlclose(_handle.Value);

        _handle = null;
    }
}