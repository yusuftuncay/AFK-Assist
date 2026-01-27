using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AFK_Assist.Helpers;

static partial class GameWindowFinder
{
    // Show Flags
    private const int SwShowMaximized = 3;

    // Target Names
    private static readonly string[] _knownTargetProcessNames =
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

    public static bool TryFocusKnownGameWindow(bool switchToGameEnabled)
    {
        // Skip When Disabled
        if (!switchToGameEnabled)
            return false;

        // Find Candidate Window
        var windowHandle = FindFirstMainWindow();
        if (windowHandle == nint.Zero)
            return false;

        // Bring Window To Front
        return MaximizeAndFocus(windowHandle);
    }

    private static nint FindFirstMainWindow()
    {
        // Iterate Known Targets
        for (var targetIndex = 0; targetIndex < _knownTargetProcessNames.Length; targetIndex++)
        {
            // Read Process Name
            var targetProcessName = _knownTargetProcessNames[targetIndex];
            if (string.IsNullOrWhiteSpace(targetProcessName))
                continue;

            // Find Matching Processes
            var processList = Process.GetProcessesByName(targetProcessName);
            if (processList == null || processList.Length == 0)
                continue;

            // Return First Main Window
            for (var processIndex = 0; processIndex < processList.Length; processIndex++)
            {
                var process = processList[processIndex];

                try
                {
                    // Refresh Process State
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

    private static bool MaximizeAndFocus(nint windowHandle)
    {
        // Maximize Target Window
        ShowWindow(windowHandle, SwShowMaximized);

        // Try Simple Foreground
        if (TryForeground(windowHandle))
            return true;

        // Resolve Thread Ids
        var currentForegroundHandle = GetForegroundWindow();
        var foregroundThreadId = GetWindowThreadIdSafe(currentForegroundHandle);
        var currentThreadId = GetCurrentThreadId();

        // Attach Threads If Possible
        if (foregroundThreadId != 0 && currentThreadId != 0)
        {
            try
            {
                // Attach Input Threads
                AttachThreadInput(currentThreadId, foregroundThreadId, true);

                // Raise Window Z Order
                BringWindowToTop(windowHandle);

                // Force Foreground Window
                var setOk = SetForegroundWindow(windowHandle);
                return setOk;
            }
            finally
            {
                // Detach Input Threads
                AttachThreadInput(currentThreadId, foregroundThreadId, false);
            }
        }

        // Fallback Focus Attempt
        BringWindowToTop(windowHandle);
        return SetForegroundWindow(windowHandle);
    }

    private static bool TryForeground(nint windowHandle)
    {
        // Raise Window Z Order
        BringWindowToTop(windowHandle);

        // Attempt Foreground Set
        return SetForegroundWindow(windowHandle);
    }

    private static uint GetWindowThreadIdSafe(nint windowHandle)
    {
        // Validate Handle Value
        if (windowHandle == nint.Zero)
            return 0;

        // Read Thread Identifier
        return GetWindowThreadProcessId(windowHandle, out _);
    }
}
