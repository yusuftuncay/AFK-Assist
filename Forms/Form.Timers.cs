using System;

namespace AFK_Assist
{
    public partial class Form
    {
        // Main Tick
        private async void MainTimer_TickAsync(object sender, EventArgs e)
        {
            if (simulationCancellation?.Token.IsCancellationRequested == true)
                return;
            if (isPaused)
                return;

            await ExecuteSimulationAsync();

            var baseSeconds = 60 / TrackBarSpeed.Value;
            var jitter = (int)Math.Max(1, baseSeconds * randomNumberGenerator.Next(10, 26) / 100.0);
            SetTimerInterval(baseSeconds + jitter);
        }

        // Elapsed Tick
        private void ElapsedTimer_Tick(object sender, EventArgs e)
        {
            UpdateElapsedTimeDisplay();
        }

        // Elapsed Update
        private void UpdateElapsedTimeDisplay()
        {
            if (!(runStopwatch.IsRunning || isPaused || isSimulationRunning))
                return;

            var elapsed = isPaused ? pausedElapsedSnapshot : runStopwatch.Elapsed;

            var elapsedHours = (int)elapsed.TotalHours;
            var elapsedMinutes = (int)elapsed.TotalMinutes % 60;
            var elapsedSeconds = (int)elapsed.TotalSeconds % 60;

            var totalSeconds = TrackBarLength.Value * 60;
            var remainingSeconds = Math.Max(0, totalSeconds - (int)elapsed.TotalSeconds);

            var remainingHours = remainingSeconds / 3600;
            var remainingMinutes = (remainingSeconds % 3600) / 60;
            var remainingSecondsOnly = remainingSeconds % 60;

            var elapsedText =
                TrackBarLength.Value >= 60 && elapsedHours > 0
                    ? $"{elapsedHours:00}:{elapsedMinutes:00}:{elapsedSeconds:00}"
                    : $"{elapsedMinutes:00}:{elapsedSeconds:00}";

            var remainingText =
                TrackBarLength.Value >= 60
                    ? $"{remainingHours:00}:{remainingMinutes:00}:{remainingSecondsOnly:00}"
                    : $"{remainingMinutes:00}:{remainingSecondsOnly:00}";

            if (LabelElapsedTime.InvokeRequired)
            {
                LabelElapsedTime.Invoke(
                    new Action(() =>
                    {
                        LabelElapsedTime.Text =
                            $"Elapsed: {elapsedText}\nRemaining: {remainingText}";
                    })
                );
            }
            else
            {
                LabelElapsedTime.Text = $"Elapsed: {elapsedText}\nRemaining: {remainingText}";
            }
        }

        // Interval Setter
        public void SetTimerInterval(int seconds)
        {
            MainTimer.Interval = seconds * 1000;
        }
    }
}
