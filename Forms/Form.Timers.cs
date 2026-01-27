using System;
using System.Threading;
using System.Threading.Tasks;

namespace AFK_Assist;

public partial class Form
{
    private void ElapsedTimer_Tick(object sender, EventArgs e)
    {
        // Refresh Display Text
        UpdateElapsedTimeDisplay();
    }

    private async Task RunSimulationLoopAsync(CancellationToken cancellationToken)
    {
        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // Wait While Paused
                if (_isPaused || !_isSimulationRunning)
                {
                    await Task.Delay(100, cancellationToken);
                    continue;
                }

                // Read Configured Speed
                var simulationsPerMinute = Math.Max(1, TrackBarSpeed.Value);

                // Calculate Active Bucket Time
                var elapsedSeconds = _runStopwatch.Elapsed.TotalSeconds;
                var minuteBucketIndex = (int)(elapsedSeconds / 60.0);
                var secondWithinBucket = elapsedSeconds - (minuteBucketIndex * 60.0);

                // Create New Bucket Schedule
                if (
                    minuteBucketIndex != _currentMinuteBucketIndex
                    || _currentMinuteBucketScheduleSeconds == null
                )
                {
                    _currentMinuteBucketIndex = minuteBucketIndex;
                    _currentMinuteBucketStepIndex = 0;
                    _currentMinuteBucketScheduleSeconds = GenerateMinuteScheduleSeconds(
                        simulationsPerMinute
                    );
                }

                // Wait For Next Bucket
                if (_currentMinuteBucketStepIndex >= _currentMinuteBucketScheduleSeconds.Length)
                {
                    await Task.Delay(50, cancellationToken);
                    continue;
                }

                // Resolve Next Due Timestamp
                var nextDueSecond = _currentMinuteBucketScheduleSeconds[
                    _currentMinuteBucketStepIndex
                ];

                // Wait Until Due Time
                if (secondWithinBucket + 0.001 < nextDueSecond)
                {
                    var waitMilliseconds = (int)
                        Math.Max(1, (nextDueSecond - secondWithinBucket) * 1000.0);
                    waitMilliseconds = Math.Min(waitMilliseconds, 250);
                    await Task.Delay(waitMilliseconds, cancellationToken);
                    continue;
                }

                // Execute One Simulation
                await ExecuteSimulationAsync();
                _currentMinuteBucketStepIndex++;

                // Yield Briefly
                await Task.Delay(1, cancellationToken);
            }
        }
        catch (TaskCanceledException) { }
        catch (Exception exception)
        {
            // Log Unexpected Errors
            UpdateLog($"Simulation Loop Error: {exception.Message}");
        }
    }

    private double[] GenerateMinuteScheduleSeconds(int simulationsPerMinute)
    {
        // Compute Base Interval
        var baseIntervalSeconds = 60.0 / simulationsPerMinute;

        // Configure Jitter Bounds
        var maxJitterFraction = 0.35;
        var minimumIntervalSeconds = Math.Max(0.35, baseIntervalSeconds * 0.40);
        var maximumIntervalSeconds = Math.Min(30.0, baseIntervalSeconds * 1.80);

        // Create Jittered Intervals
        var intervals = new double[simulationsPerMinute];

        for (var intervalIndex = 0; intervalIndex < simulationsPerMinute; intervalIndex++)
        {
            var jitterSeconds =
                (2.0 * _randomNumberGenerator.NextDouble() - 1.0)
                * (baseIntervalSeconds * maxJitterFraction);

            intervals[intervalIndex] = baseIntervalSeconds + jitterSeconds;
        }

        // Clamp Intervals Safely
        for (var intervalIndex = 0; intervalIndex < intervals.Length; intervalIndex++)
        {
            intervals[intervalIndex] = Math.Clamp(
                intervals[intervalIndex],
                minimumIntervalSeconds,
                maximumIntervalSeconds
            );
        }

        // Normalize Total To One Minute
        NormalizeIntervalsToTarget(
            intervals,
            targetSum: 60.0,
            minimumIntervalSeconds,
            maximumIntervalSeconds
        );

        // Convert Intervals To Due Times
        var dueSeconds = new double[simulationsPerMinute];
        var cumulativeSeconds = 0.0;

        for (var stepIndex = 0; stepIndex < simulationsPerMinute; stepIndex++)
        {
            dueSeconds[stepIndex] = cumulativeSeconds;
            cumulativeSeconds += intervals[stepIndex];
        }

        // Add Small Phase Shift
        var shiftMaximumSeconds = Math.Min(0.75, baseIntervalSeconds * 0.25);
        var shiftSeconds = _randomNumberGenerator.NextDouble() * shiftMaximumSeconds;

        for (var stepIndex = 0; stepIndex < dueSeconds.Length; stepIndex++)
        {
            var shifted = dueSeconds[stepIndex] + shiftSeconds;
            dueSeconds[stepIndex] = shifted >= 60.0 ? shifted - 60.0 : shifted;
        }

        // Ensure Ascending Order
        Array.Sort(dueSeconds);

        // Avoid Exact Boundary Hit
        if (dueSeconds.Length > 0 && dueSeconds[0] < 0.05)
        {
            dueSeconds[0] = 0.05;
            Array.Sort(dueSeconds);
        }

        return dueSeconds;
    }

    private static void NormalizeIntervalsToTarget(
        double[] intervals,
        double targetSum,
        double minimumInterval,
        double maximumInterval
    )
    {
        for (var iterationIndex = 0; iterationIndex < 12; iterationIndex++)
        {
            // Compute Current Sum
            var currentSum = 0.0;
            for (var intervalIndex = 0; intervalIndex < intervals.Length; intervalIndex++)
                currentSum += intervals[intervalIndex];

            // Compute Remaining Error
            var errorSeconds = targetSum - currentSum;
            if (Math.Abs(errorSeconds) < 0.0005)
                return;

            // Distribute Positive Error
            if (errorSeconds > 0)
            {
                var availableRoom = 0.0;
                for (var intervalIndex = 0; intervalIndex < intervals.Length; intervalIndex++)
                    availableRoom += (maximumInterval - intervals[intervalIndex]);

                if (availableRoom <= 0.0001)
                    return;

                for (var intervalIndex = 0; intervalIndex < intervals.Length; intervalIndex++)
                {
                    var roomForInterval = maximumInterval - intervals[intervalIndex];
                    var addSeconds = errorSeconds * (roomForInterval / availableRoom);
                    intervals[intervalIndex] = Math.Min(
                        maximumInterval,
                        intervals[intervalIndex] + addSeconds
                    );
                }
            }
            else
            {
                // Distribute Negative Error
                var availableRoom = 0.0;
                for (var intervalIndex = 0; intervalIndex < intervals.Length; intervalIndex++)
                    availableRoom += (intervals[intervalIndex] - minimumInterval);

                if (availableRoom <= 0.0001)
                    return;

                for (var intervalIndex = 0; intervalIndex < intervals.Length; intervalIndex++)
                {
                    var roomForInterval = intervals[intervalIndex] - minimumInterval;
                    var subtractSeconds = errorSeconds * (roomForInterval / availableRoom);
                    intervals[intervalIndex] = Math.Max(
                        minimumInterval,
                        intervals[intervalIndex] + subtractSeconds
                    );
                }
            }

            // Enforce Hard Bounds
            for (var intervalIndex = 0; intervalIndex < intervals.Length; intervalIndex++)
                intervals[intervalIndex] = Math.Clamp(
                    intervals[intervalIndex],
                    minimumInterval,
                    maximumInterval
                );
        }

        // Apply Final Correction
        var finalSum = 0.0;
        var largestIndex = 0;

        for (var intervalIndex = 0; intervalIndex < intervals.Length; intervalIndex++)
        {
            finalSum += intervals[intervalIndex];
            if (intervals[intervalIndex] > intervals[largestIndex])
                largestIndex = intervalIndex;
        }

        var finalError = targetSum - finalSum;
        if (Math.Abs(finalError) < 0.0005)
            return;

        intervals[largestIndex] = Math.Clamp(
            intervals[largestIndex] + finalError,
            minimumInterval,
            maximumInterval
        );
    }

    private void UpdateElapsedTimeDisplay()
    {
        if (!(_runStopwatch.IsRunning || _isPaused || _isSimulationRunning))
            return;

        // Resolve Current Elapsed
        var elapsed = _isPaused ? _pausedElapsedSnapshot : _runStopwatch.Elapsed;

        // Compute Elapsed Units
        var elapsedHours = (int)elapsed.TotalHours;
        var elapsedMinutes = (int)elapsed.TotalMinutes % 60;
        var elapsedSeconds = (int)elapsed.TotalSeconds % 60;

        // Compute Remaining Units
        var totalSeconds = TrackBarLength.Value * 60;
        var remainingSeconds = Math.Max(0, totalSeconds - (int)elapsed.TotalSeconds);

        var remainingHours = remainingSeconds / 3600;
        var remainingMinutes = (remainingSeconds % 3600) / 60;
        var remainingSecondsOnly = remainingSeconds % 60;

        // Format Elapsed Text
        var elapsedText =
            TrackBarLength.Value >= 60 && elapsedHours > 0
                ? $"{elapsedHours:00}:{elapsedMinutes:00}:{elapsedSeconds:00}"
                : $"{elapsedMinutes:00}:{elapsedSeconds:00}";

        // Format Remaining Text
        var remainingText =
            TrackBarLength.Value >= 60
                ? $"{remainingHours:00}:{remainingMinutes:00}:{remainingSecondsOnly:00}"
                : $"{remainingMinutes:00}:{remainingSecondsOnly:00}";

        // Update Label Safely
        if (LabelElapsedTime.InvokeRequired)
        {
            LabelElapsedTime.Invoke(
                new Action(() =>
                {
                    LabelElapsedTime.Text = $"Elapsed: {elapsedText}\nRemaining: {remainingText}";
                })
            );
        }
        else
        {
            LabelElapsedTime.Text = $"Elapsed: {elapsedText}\nRemaining: {remainingText}";
        }
    }
}
