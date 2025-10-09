using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFK_Assist.Services
{
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

    internal static class UpdateChecker
    {
        private const string LatestUrl =
            "https://github.com/yusuftuncay/AFK-Assist/releases/latest";

        /// <summary>
        ///  Checks GitHub's /releases/latest redirect and compares it to the app version.
        ///  If something goes wrong, <c>UpdateAvailable</c> will be false.
        /// </summary>
        /// <returns><c>UpdateCheckResult</c></returns>
        public static async Task<UpdateCheckResult> CheckAsync()
        {
            try
            {
                Version current = GetCurrentVersion();

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
                        return new UpdateCheckResult(false, current, current, string.Empty);

                    var locationHeader = response.Headers.Location;
                    var location =
                        locationHeader == null ? string.Empty : locationHeader.ToString();
                    if (string.IsNullOrEmpty(location))
                        return new UpdateCheckResult(false, current, current, string.Empty);

                    // Example: /yusuftuncay/AFK-Assist/releases/tag/v2.1.1
                    int lastSlash = location.LastIndexOf('/');
                    // v2.1.1
                    string tag = lastSlash >= 0 ? location.Substring(lastSlash + 1) : location;

                    // 2.1.1
                    Version latestVersion = ParseVersionFromTag(tag);
                    bool hasUpdate = latestVersion > current;
                    string latestReleaseUrl = "https://github.com" + location;

                    return new UpdateCheckResult(
                        hasUpdate,
                        current,
                        latestVersion,
                        latestReleaseUrl
                    );
                }
            }
            catch
            {
                // Report "No Update"
                Version current = GetSafeVersion(Application.ProductVersion);
                return new UpdateCheckResult(false, current, current, string.Empty);
            }
        }

        public static void OpenRelease(string url)
        {
            if (string.IsNullOrEmpty(url))
                return;
            Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
        }

        #region Helpers
        private static bool IsRedirect(HttpStatusCode code)
        {
            int statusCode = (int)code;
            return statusCode >= 300 && statusCode <= 399;
        }

        private static Version GetCurrentVersion()
        {
            // ProductVersion Maps to AssemblyFileVersion by Default (e.g., "2.1.1")
            // We Normalize to Major.Minor.Patch for Comparison
            return GetSafeVersion(Application.ProductVersion);
        }

        private static Version ParseVersionFromTag(string tag)
        {
            if (string.IsNullOrEmpty(tag))
                return new Version(0, 0, 0);

            // Trim Leading v/V (e.g., "v2.1.1")
            if (tag.Length > 0 && (tag[0] == 'v' || tag[0] == 'V'))
                tag = tag.Substring(1);
            return GetSafeVersion(tag);
        }

        private static Version GetSafeVersion(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new Version(0, 0, 0);

            // Normalize to Major.Minor.Patch
            // Accepts Inputs Like: "2.1.1" or "2.1" or "2"
            string[] parts = text.Split('.');
            string normalized;

            if (parts.Length >= 3)
                normalized = parts[0] + "." + parts[1] + "." + parts[2];
            else if (parts.Length == 2)
                normalized = parts[0] + "." + parts[1] + ".0";
            else if (parts.Length == 1)
                normalized = parts[0] + ".0.0";
            else
                normalized = "0.0.0";

            if (!Version.TryParse(normalized, out Version safeVersion))
                safeVersion = new Version(0, 0, 0);
            return safeVersion;
        }
        #endregion
    }
}
