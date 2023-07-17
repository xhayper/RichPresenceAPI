using System.Runtime.InteropServices;

namespace RichPresenceAPI.Native;

public class libdl
{
    public enum OPEN_FLAGS
    {
        RTLD_NOW_64_BIT = 2,
        RTLD_NOW_32_BIT = 0,
        RTLD_LAZY = 1,
        RTLD_LOCAL = 0,
        RTLD_GLOBAL_64_BIT = 0x00100,
        RTLD_GLOBAL_32_BIT = 2,
        RTLD_NOLOAD = 4,
        RTLD_NODELETE = 0x01000
    }

    [DllImport("libdl", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr dlopen(string file, int mode);

    [DllImport("libdl", CharSet = CharSet.Auto)]
    public static extern void dlclose(IntPtr handle);
}