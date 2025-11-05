using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFK_Assist.Services
{
    // Update Result
    internal sealed class UpdateCheckResult
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

    // Update Checker
    internal static class UpdateChecker
    {
        // Latest Url
        private const string LatestUrl =
            "https://github.com/yusuftuncay/AFK-Assist/releases/latest";

        #region Public API
        // Check For Update
        public static async Task<UpdateCheckResult> CheckAsync()
        {
            try
            {
                Version currentVersion = GetCurrentVersion();

                using (
                    var httpClient = new HttpClient(
                        new HttpClientHandler { AllowAutoRedirect = false }
                    )
                )
                {
                    httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                        "AFK-Assist-UpdateChecker/1.0"
                    );

                    var response = await httpClient.GetAsync(LatestUrl).ConfigureAwait(false);
                    if (!IsRedirect(response.StatusCode))
                        return new UpdateCheckResult(
                            false,
                            currentVersion,
                            currentVersion,
                            string.Empty
                        );

                    var locationHeader = response.Headers.Location;
                    var location =
                        locationHeader == null ? string.Empty : locationHeader.ToString();
                    if (string.IsNullOrEmpty(location))
                        return new UpdateCheckResult(
                            false,
                            currentVersion,
                            currentVersion,
                            string.Empty
                        );

                    var lastSlash = location.LastIndexOf('/');
                    var tag = lastSlash >= 0 ? location.Substring(lastSlash + 1) : location;

                    var latestVersion = ParseVersionFromTag(tag);
                    var hasUpdate = latestVersion > currentVersion;
                    var latestReleaseUrl = "https://github.com" + location;

                    return new UpdateCheckResult(
                        hasUpdate,
                        currentVersion,
                        latestVersion,
                        latestReleaseUrl
                    );
                }
            }
            catch
            {
                var current = GetSafeVersion(Application.ProductVersion);
                return new UpdateCheckResult(false, current, current, string.Empty);
            }
        }

        // Open Release
        public static void OpenRelease(string url)
        {
            if (string.IsNullOrEmpty(url))
                return;

            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }
        #endregion

        #region Helpers
        // Redirect Check
        private static bool IsRedirect(HttpStatusCode code)
        {
            var statusCode = (int)code;
            return statusCode >= 300 && statusCode <= 399;
        }

        // Current Version
        private static Version GetCurrentVersion()
        {
            return GetSafeVersion(Application.ProductVersion);
        }

        // Parse Version Tag
        private static Version ParseVersionFromTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
                return new Version(0, 0, 0);
            if (tag.Length > 0 && (tag[0] == 'v' || tag[0] == 'V'))
                tag = tag.Substring(1);
            return GetSafeVersion(tag);
        }

        // Safe Version Parse
        private static Version GetSafeVersion(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new Version(0, 0, 0);

            string[] parts = text.Split('.');
            var normalized =
                parts.Length >= 3 ? parts[0] + "." + parts[1] + "." + parts[2]
                : parts.Length == 2 ? parts[0] + "." + parts[1] + ".0"
                : parts.Length == 1 ? parts[0] + ".0.0"
                : "0.0.0";

            if (!Version.TryParse(normalized, out Version safeVersion))
                safeVersion = new Version(0, 0, 0);

            return safeVersion;
        }
        #endregion
    }
}
