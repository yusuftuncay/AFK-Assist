using System.Runtime.InteropServices;

namespace AFK_Assist.Helpers;

// Native Interop
public static partial class Interop
{
    // Mouse Flags
    public const uint MOUSEEVENTF_LEFTDOWN = 0x02;
    public const uint MOUSEEVENTF_LEFTUP = 0x04;
    public const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
    public const uint MOUSEEVENTF_RIGHTUP = 0x10;

    // Key Flags
    public const int KEYEVENTF_EXTENDEDKEY = 0x0001;
    public const int KEYEVENTF_KEYUP = 0x0002;

    // Mouse Event
    [LibraryImport("user32.dll")]
    internal static partial void mouse_event(
        uint dwFlags,
        uint dx,
        uint dy,
        uint cButtons,
        uint dwExtraInfo
    );

    // Key Event
    [LibraryImport("user32.dll")]
    internal static partial void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
}
