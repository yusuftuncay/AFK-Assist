using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AFK_Assist.Helpers;

static partial class GameWindowFinder
{
    // Show Flags
    private const int SW_SHOWMAXIMIZED = 3;

    // Win32 Imports
    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool ShowWindow(nint windowHandle, int command);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool BringWindowToTop(nint windowHandle);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool SetForegroundWindow(nint windowHandle);

    [LibraryImport("user32.dll")]
    private static partial nint GetForegroundWindow();

    [LibraryImport("user32.dll")]
    private static partial uint GetWindowThreadProcessId(nint windowHandle, out uint processId);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool AttachThreadInput(
        uint idAttach,
        uint idAttachTo,
        [MarshalAs(UnmanagedType.Bool)] bool attach
    );

    [LibraryImport("kernel32.dll")]
    private static partial uint GetCurrentThreadId();

    // Target Names
    private static readonly string[] s_knownTargetNames =
    [
        // Test Targets
        "notepad",
        // Game Targets
        "blackops6",
        "cod",
        "codmw",
        "cs2",
        "csgo",
        "fifa23",
        "fifa24",
        "fifa25",
        "gta5",
        "overwatch",
        "overwatch2",
        "r5apex",
        "rocketleague",
        "valorant",
    ];

    // Public Entry
    public static bool TryFocusKnownGameWindow(bool switchToGameEnabled)
    {
        if (!switchToGameEnabled)
            return false;

        var windowHandle = FindFirstMainWindow();
        if (windowHandle == nint.Zero)
            return false;

        return MaximizeAndFocus(windowHandle);
    }

    // Find First Main Window
    private static nint FindFirstMainWindow()
    {
        for (var index = 0; index < s_knownTargetNames.Length; index++)
        {
            var targetProcessName = s_knownTargetNames[index];
            if (string.IsNullOrWhiteSpace(targetProcessName))
                continue;

            var processList = Process.GetProcessesByName(targetProcessName);
            if (processList == null || processList.Length == 0)
                continue;

            for (var p = 0; p < processList.Length; p++)
            {
                var process = processList[p];
                try
                {
                    process.Refresh();
                }
                catch { }

                var handle = process.MainWindowHandle;
                if (handle != nint.Zero)
                    return handle;
            }
        }
        return nint.Zero;
    }

    // Maximize And Focus
    private static bool MaximizeAndFocus(nint windowHandle)
    {
        ShowWindow(windowHandle, SW_SHOWMAXIMIZED);

        if (TryForeground(windowHandle))
            return true;

        var currentForeground = GetForegroundWindow();
        var foregroundThreadId = GetWindowThreadIdSafe(currentForeground);
        var currentThreadId = GetCurrentThreadId();
        if (foregroundThreadId != 0 && currentThreadId != 0)
        {
            try
            {
                AttachThreadInput(currentThreadId, foregroundThreadId, true);
                BringWindowToTop(windowHandle);
                var setOk = SetForegroundWindow(windowHandle);
                return setOk;
            }
            finally
            {
                AttachThreadInput(currentThreadId, foregroundThreadId, false);
            }
        }

        BringWindowToTop(windowHandle);
        return SetForegroundWindow(windowHandle);
    }

    // Foreground Try
    private static bool TryForeground(nint windowHandle)
    {
        BringWindowToTop(windowHandle);
        return SetForegroundWindow(windowHandle);
    }

    // Safe Thread Id
    private static uint GetWindowThreadIdSafe(nint windowHandle)
    {
        if (windowHandle == nint.Zero)
            return 0;

        GetWindowThreadProcessId(windowHandle, out var _);
        return GetWindowThreadProcessId(windowHandle, out _);
    }
}
