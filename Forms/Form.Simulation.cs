using AFK_Assist.Classes;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFK_Assist
{
    public partial class Form
    {
        // Execute Step
        private async Task ExecuteSimulationAsync()
        {
            if (simulationCancellation?.Token.IsCancellationRequested == true)
                return;

            if (RandomizeToolStripMenuItem.Checked)
                await RandomizeKeyPressesAsync();
            else
                await SequentialKeyPressesAsync();

            if (simulationCancellation?.Token.IsCancellationRequested == true)
                return;

            await ExecuteMouseClicksAsync();
        }

        // Random Keys
        private async Task RandomizeKeyPressesAsync()
        {
            bool[] used = new bool[4];
            var count = 0;

            while (count < 4)
            {
                if (simulationCancellation?.Token.IsCancellationRequested == true)
                    return;

                var index = RandomDelay.NextIndex(randomNumberGenerator, 4);
                if (used[index])
                    continue;

                await ExecuteKeyPressAsync(index);
                used[index] = true;
                count++;

                if (RandomizeIntervalsToolStripMenuItem.Checked)
                    await Task.Delay(RandomDelay.BetweenKeypress(randomNumberGenerator));
            }
        }

        // Sequential Keys
        private async Task SequentialKeyPressesAsync()
        {
            if (AzertyToolStripMenuItem.Checked)
            {
                await ExecuteKeyPressAsync(4);
                if (RandomizeIntervalsToolStripMenuItem.Checked)
                    await Task.Delay(RandomDelay.BetweenKeypress(randomNumberGenerator));
                await ExecuteKeyPressAsync(5);
                if (RandomizeIntervalsToolStripMenuItem.Checked)
                    await Task.Delay(RandomDelay.BetweenKeypress(randomNumberGenerator));
            }
            else
            {
                await ExecuteKeyPressAsync(0);
                if (RandomizeIntervalsToolStripMenuItem.Checked)
                    await Task.Delay(RandomDelay.BetweenKeypress(randomNumberGenerator));
                await ExecuteKeyPressAsync(1);
                if (RandomizeIntervalsToolStripMenuItem.Checked)
                    await Task.Delay(RandomDelay.BetweenKeypress(randomNumberGenerator));
            }

            await ExecuteKeyPressAsync(2);
            if (RandomizeIntervalsToolStripMenuItem.Checked)
                await Task.Delay(RandomDelay.BetweenKeypress(randomNumberGenerator));
            await ExecuteKeyPressAsync(3);
        }

        // Key Switch
        private async Task ExecuteKeyPressAsync(int keyIndex)
        {
            switch (keyIndex)
            {
                case 0:
                    if (WKeyCheckBox.Checked)
                        await PressAndReleaseKeyAsync(Keys.W, "Pressed W Key");
                    break;
                case 1:
                    if (AKeyCheckBox.Checked)
                        await PressAndReleaseKeyAsync(Keys.A, "Pressed A Key");
                    break;
                case 2:
                    if (SKeyCheckBox.Checked)
                        await PressAndReleaseKeyAsync(Keys.S, "Pressed S Key");
                    break;
                case 3:
                    if (DKeyCheckBox.Checked)
                        await PressAndReleaseKeyAsync(Keys.D, "Pressed D Key");
                    break;
                case 4:
                    if (WKeyCheckBox.Checked)
                        await PressAndReleaseKeyAsync(Keys.Z, "Pressed Z Key");
                    break;
                case 5:
                    if (AKeyCheckBox.Checked)
                        await PressAndReleaseKeyAsync(Keys.Q, "Pressed Q Key");
                    break;
            }
        }

        // Press And Release
        private async Task PressAndReleaseKeyAsync(Keys key, string logMessage)
        {
            UpdateLog(logMessage);

            var holdMilliseconds = RandomizeIntervalsToolStripMenuItem.Checked
                ? RandomDelay.KeyHold(randomNumberGenerator)
                : 100;

            await Task.Run(() =>
            {
                Interop.keybd_event((byte)key, 0x45, Interop.KEYEVENTF_EXTENDEDKEY, 0);
                Thread.Sleep(holdMilliseconds);
                Interop.keybd_event((byte)key, 0x45, Interop.KEYEVENTF_KEYUP, 0);
            });
        }

        // Mouse Clicks
        private async Task ExecuteMouseClicksAsync()
        {
            if (MouseClickLeftCheckBox.Checked)
            {
                UpdateLog("Clicked Left Mouse");

                var holdMilliseconds = RandomizeIntervalsToolStripMenuItem.Checked
                    ? RandomDelay.MouseHold(randomNumberGenerator)
                    : 100;

                await Task.Run(() =>
                {
                    Interop.mouse_event(Interop.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    Thread.Sleep(holdMilliseconds);
                    Interop.mouse_event(Interop.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                });
            }

            if (MouseClickRightCheckBox.Checked)
            {
                UpdateLog("Clicked Right Mouse");

                var holdMilliseconds = RandomizeIntervalsToolStripMenuItem.Checked
                    ? RandomDelay.MouseHold(randomNumberGenerator)
                    : 100;

                await Task.Run(() =>
                {
                    Interop.mouse_event(Interop.MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                    Thread.Sleep(holdMilliseconds);
                    Interop.mouse_event(Interop.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                });
            }
        }
    }
}
