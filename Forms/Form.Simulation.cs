using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AFK_Assist.Helpers;

namespace AFK_Assist;

public partial class Form
{
    private sealed record KeyStep(Keys Key, string LogMessage);

    private async Task ExecuteSimulationAsync()
    {
        // Check Cancellation
        if (_simulationCancellation?.Token.IsCancellationRequested == true)
            return;

        // Execute Keyboard First
        if (RandomizeToolStripMenuItem.Checked)
            await RandomizeKeyPressesAsync();
        else
            await SequentialKeyPressesAsync();

        // Check Cancellation
        if (_simulationCancellation?.Token.IsCancellationRequested == true)
            return;

        // Execute Mouse Last
        await ExecuteMouseClicksAsync();
    }

    private List<KeyStep> GetSelectedKeySteps()
    {
        // Prepare Key Mapping
        var wKey = AzertyToolStripMenuItem.Checked ? Keys.Z : Keys.W;
        var aKey = AzertyToolStripMenuItem.Checked ? Keys.Q : Keys.A;

        // Create Selected List
        var steps = new List<KeyStep>(capacity: 4);

        if (WKeyCheckBox.Checked)
            steps.Add(
                new KeyStep(
                    wKey,
                    AzertyToolStripMenuItem.Checked ? "Pressed Z Key" : "Pressed W Key"
                )
            );

        if (AKeyCheckBox.Checked)
            steps.Add(
                new KeyStep(
                    aKey,
                    AzertyToolStripMenuItem.Checked ? "Pressed Q Key" : "Pressed A Key"
                )
            );

        if (SKeyCheckBox.Checked)
            steps.Add(new KeyStep(Keys.S, "Pressed S Key"));

        if (DKeyCheckBox.Checked)
            steps.Add(new KeyStep(Keys.D, "Pressed D Key"));

        return steps;
    }

    private async Task RandomizeKeyPressesAsync()
    {
        // Get Selected Keys
        var selectedSteps = GetSelectedKeySteps();
        if (selectedSteps.Count == 0)
            return;

        // Shuffle Selected Steps
        for (var currentIndex = selectedSteps.Count - 1; currentIndex > 0; currentIndex--)
        {
            var swapIndex = _randomNumberGenerator.Next(0, currentIndex + 1);
            (selectedSteps[currentIndex], selectedSteps[swapIndex]) = (
                selectedSteps[swapIndex],
                selectedSteps[currentIndex]
            );
        }

        foreach (var step in selectedSteps)
        {
            // Check Cancellation
            if (_simulationCancellation?.Token.IsCancellationRequested == true)
                return;

            // Press Selected Key
            await PressAndReleaseKeyAsync(step.Key, step.LogMessage);

            // Add Optional Delay
            if (RandomizeIntervalsToolStripMenuItem.Checked)
                await Task.Delay(RandomDelay.BetweenKeypress(_randomNumberGenerator));
        }
    }

    private async Task SequentialKeyPressesAsync()
    {
        // Rebuild Ordered Keys
        var wKey = AzertyToolStripMenuItem.Checked ? Keys.Z : Keys.W;
        var aKey = AzertyToolStripMenuItem.Checked ? Keys.Q : Keys.A;

        var orderedSteps = new List<KeyStep>(capacity: 4);

        if (WKeyCheckBox.Checked)
            orderedSteps.Add(
                new KeyStep(
                    wKey,
                    AzertyToolStripMenuItem.Checked ? "Pressed Z Key" : "Pressed W Key"
                )
            );

        if (AKeyCheckBox.Checked)
            orderedSteps.Add(
                new KeyStep(
                    aKey,
                    AzertyToolStripMenuItem.Checked ? "Pressed Q Key" : "Pressed A Key"
                )
            );

        if (SKeyCheckBox.Checked)
            orderedSteps.Add(new KeyStep(Keys.S, "Pressed S Key"));

        if (DKeyCheckBox.Checked)
            orderedSteps.Add(new KeyStep(Keys.D, "Pressed D Key"));

        // Skip When Nothing Selected
        if (orderedSteps.Count == 0)
            return;

        foreach (var step in orderedSteps)
        {
            // Check Cancellation
            if (_simulationCancellation?.Token.IsCancellationRequested == true)
                return;

            // Press Selected Key
            await PressAndReleaseKeyAsync(step.Key, step.LogMessage);

            // Add Optional Delay
            if (RandomizeIntervalsToolStripMenuItem.Checked)
                await Task.Delay(RandomDelay.BetweenKeypress(_randomNumberGenerator));
        }
    }

    private async Task PressAndReleaseKeyAsync(Keys key, string logMessage)
    {
        // Write Action Log
        UpdateLog(logMessage);

        // Determine Hold Duration
        var holdMilliseconds = RandomizeIntervalsToolStripMenuItem.Checked
            ? RandomDelay.KeyHold(_randomNumberGenerator)
            : 100;

        await Task.Run(() =>
        {
            // Press Key Down
            Interop.keybd_event((byte)key, 0x45, Interop.KEYEVENTF_EXTENDEDKEY, 0);

            // Hold Key Briefly
            Thread.Sleep(holdMilliseconds);

            // Release Key Up
            Interop.keybd_event((byte)key, 0x45, Interop.KEYEVENTF_KEYUP, 0);
        });
    }

    private async Task ExecuteMouseClicksAsync()
    {
        if (MouseClickLeftCheckBox.Checked)
        {
            // Write Action Log
            UpdateLog("Clicked Left Mouse");

            // Determine Hold Duration
            var holdMilliseconds = RandomizeIntervalsToolStripMenuItem.Checked
                ? RandomDelay.MouseHold(_randomNumberGenerator)
                : 100;

            await Task.Run(() =>
            {
                // Press Mouse Down
                Interop.mouse_event(Interop.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);

                // Hold Button Briefly
                Thread.Sleep(holdMilliseconds);

                // Release Mouse Up
                Interop.mouse_event(Interop.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            });
        }

        if (MouseClickRightCheckBox.Checked)
        {
            // Write Action Log
            UpdateLog("Clicked Right Mouse");

            // Determine Hold Duration
            var holdMilliseconds = RandomizeIntervalsToolStripMenuItem.Checked
                ? RandomDelay.MouseHold(_randomNumberGenerator)
                : 100;

            await Task.Run(() =>
            {
                // Press Mouse Down
                Interop.mouse_event(Interop.MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);

                // Hold Button Briefly
                Thread.Sleep(holdMilliseconds);

                // Release Mouse Up
                Interop.mouse_event(Interop.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            });
        }
    }
}
