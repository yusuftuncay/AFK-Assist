using System;

namespace AFK_Assist.Classes;

public sealed class UpdateCheckResult
{
    public bool UpdateAvailable { get; }
    public Version Current { get; }
    public Version Latest { get; }
    public string ReleaseUrl { get; }

    public UpdateCheckResult(
        bool updateAvailable,
        Version current,
        Version latest,
        string releaseUrl
    )
    {
        UpdateAvailable = updateAvailable;
        Current = current;
        Latest = latest;
        ReleaseUrl = releaseUrl ?? string.Empty;
    }
}
