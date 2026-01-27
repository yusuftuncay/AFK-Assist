using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using AFK_Assist.Classes;

namespace AFK_Assist.Helpers;

public static class UpdateChecker
{
    // Update Endpoint
    private const string LatestUrl = "https://github.com/yusuftuncay/AFK-Assist/releases/latest";

    #region Public API
    public static async Task<UpdateCheckResult> CheckAsync()
    {
        try
        {
            // Read Current Version
            var currentVersion = GetCurrentVersion();

            using var httpClient = new HttpClient(
                new HttpClientHandler { AllowAutoRedirect = false }
            );

            // Set Client Headers
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("AFK-Assist-UpdateChecker/1.0");

            // Request Latest Release
            var response = await httpClient.GetAsync(LatestUrl).ConfigureAwait(false);

            // Validate Redirect Response
            if (!IsRedirect(response.StatusCode))
                return new UpdateCheckResult(false, currentVersion, currentVersion, string.Empty);

            // Read Location Header
            var locationHeader = response.Headers.Location;
            var location = locationHeader == null ? string.Empty : locationHeader.ToString();

            // Validate Location Header
            if (string.IsNullOrEmpty(location))
                return new UpdateCheckResult(false, currentVersion, currentVersion, string.Empty);

            // Extract Tag From Url
            var lastSlashIndex = location.LastIndexOf('/');
            var tag = lastSlashIndex >= 0 ? location.Substring(lastSlashIndex + 1) : location;

            // Parse Latest Version
            var latestVersion = ParseVersionFromTag(tag);

            // Compare Version Numbers
            var hasUpdate = latestVersion > currentVersion;

            return new UpdateCheckResult(hasUpdate, currentVersion, latestVersion, location);
        }
        catch
        {
            // Return Safe Fallback
            var currentVersion = GetSafeVersion(Application.ProductVersion);
            return new UpdateCheckResult(false, currentVersion, currentVersion, string.Empty);
        }
    }

    public static void OpenRelease(string url)
    {
        // Validate Input Url
        if (string.IsNullOrEmpty(url))
            return;

        // Launch Browser Url
        Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
    }

    public static Version GetCurrentVersion()
    {
        // Parse Application Version
        return GetSafeVersion(Application.ProductVersion);
    }
    #endregion

    #region Helpers
    // Redirect Check
    private static bool IsRedirect(HttpStatusCode code)
    {
        // Convert To Integer
        var statusCode = (int)code;

        // Check Redirect Range
        return statusCode >= 300 && statusCode <= 399;
    }

    private static Version ParseVersionFromTag(string tag)
    {
        // Validate Tag Text
        if (string.IsNullOrEmpty(tag))
            return new Version(0, 0, 0);

        // Strip Leading Prefix
        if (tag.Length > 0 && (tag[0] == 'v' || tag[0] == 'V'))
            tag = tag.Substring(1);

        // Parse Safe Version
        return GetSafeVersion(tag);
    }

    private static Version GetSafeVersion(string text)
    {
        // Validate Version Text
        if (string.IsNullOrEmpty(text))
            return new Version(0, 0, 0);

        // Remove Build Suffix
        var plusIndex = text.IndexOf('+');
        if (plusIndex >= 0)
            text = text.Substring(0, plusIndex);

        // Normalize Version Parts
        var parts = text.Split('.');
        var normalized =
            parts.Length >= 3 ? parts[0] + "." + parts[1] + "." + parts[2]
            : parts.Length == 2 ? parts[0] + "." + parts[1] + ".0"
            : parts.Length == 1 ? parts[0] + ".0.0"
            : "0.0.0";

        // Try Parse Version
        if (!Version.TryParse(normalized, out var safeVersion))
            safeVersion = new Version(0, 0, 0);

        return safeVersion;
    }
    #endregion
}
