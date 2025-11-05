using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AFK_Assist.Classes
{
    // Find And Focus Target
    internal static class GameWindowFinder
    {
        // Show Flags
        private const int SW_SHOWMAXIMIZED = 3;

        // Win32 Imports
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr windowHandle, int command);

        [DllImport("user32.dll")]
        private static extern bool BringWindowToTop(IntPtr windowHandle);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr windowHandle);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(
            IntPtr windowHandle,
            out uint processId
        );

        [DllImport("user32.dll")]
        private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool attach);

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        // Target Names
        private static readonly string[] KnownTargetNames =
        {
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
        };

        // Public Entry
        public static bool TryFocusKnownGameWindow(bool switchToGameEnabled)
        {
            if (!switchToGameEnabled)
                return false;

            IntPtr windowHandle = FindFirstMainWindow();
            if (windowHandle == IntPtr.Zero)
                return false;

            return MaximizeAndFocus(windowHandle);
        }

        // Find First Main Window
        private static IntPtr FindFirstMainWindow()
        {
            for (int index = 0; index < KnownTargetNames.Length; index++)
            {
                string targetProcessName = KnownTargetNames[index];
                if (string.IsNullOrWhiteSpace(targetProcessName))
                    continue;

                Process[] processList = Process.GetProcessesByName(targetProcessName);
                if (processList == null || processList.Length == 0)
                    continue;

                for (int p = 0; p < processList.Length; p++)
                {
                    Process process = processList[p];
                    try
                    {
                        process.Refresh();
                    }
                    catch { }

                    IntPtr handle = process.MainWindowHandle;
                    if (handle != IntPtr.Zero)
                        return handle;
                }
            }
            return IntPtr.Zero;
        }

        // Maximize And Focus
        private static bool MaximizeAndFocus(IntPtr windowHandle)
        {
            ShowWindow(windowHandle, SW_SHOWMAXIMIZED);

            if (TryForeground(windowHandle))
                return true;

            IntPtr currentForeground = GetForegroundWindow();
            uint foregroundThreadId = GetWindowThreadIdSafe(currentForeground);
            uint currentThreadId = GetCurrentThreadId();
            if (foregroundThreadId != 0 && currentThreadId != 0)
            {
                try
                {
                    AttachThreadInput(currentThreadId, foregroundThreadId, true);
                    BringWindowToTop(windowHandle);
                    bool setOk = SetForegroundWindow(windowHandle);
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
        private static bool TryForeground(IntPtr windowHandle)
        {
            BringWindowToTop(windowHandle);
            return SetForegroundWindow(windowHandle);
        }

        // Safe Thread Id
        private static uint GetWindowThreadIdSafe(IntPtr windowHandle)
        {
            if (windowHandle == IntPtr.Zero)
                return 0;

            GetWindowThreadProcessId(windowHandle, out uint _);
            return GetWindowThreadProcessId(windowHandle, out _);
        }
    }
}
