using System.Runtime.InteropServices;
using System.IO;
using BepInEx;
using System;

namespace RichPresenceAPI
{
    [BepInPlugin(GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class RichPresenceAPI : BaseUnityPlugin
    {

        private static string AssemblyDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private const string GUID = "io.github.xhayper.RichPresenceAPI";
        private const string DLL_NAME = "NativeNamedPipe.dll";
        private static IntPtr hModule;

        private void Awake()
        {
            string pathToDLL = $"{AssemblyDirectory}\\{PluginInfo.PLUGIN_NAME}\\{DLL_NAME}";
            if (!File.Exists(pathToDLL)) throw new FileNotFoundException("Could not find file", pathToDLL);
            hModule = Native.LoadLibrary(pathToDLL);
            if (hModule == IntPtr.Zero) throw new Exception(String.Format("Failed to load \"{0}\" (ErrorCode: {1})", pathToDLL, Marshal.GetLastWin32Error()));
        }

        private void OnDestroy()
        {
            Native.FreeLibrary(hModule);
        }
    }
}
