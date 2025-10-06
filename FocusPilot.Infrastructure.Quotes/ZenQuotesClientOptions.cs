namespace FocusPilot.Infrastructure.Quotes;

/// <summary>
/// Configuration settings for <see cref="ZenQuotesClient"/>, including base URL, timeout, and optional API key.
/// </summary>
/// <remarks>
/// This class is intended to support external configuration binding (ie. appsettings.json or environment variables),
/// It enables flexible endpoint management and prepares for future diagnostics, dry-run support, and contributor-
/// safe overrides.
/// </remarks>
public class ZenQuotesClientOptions
{
    public string BaseUrl { get; set; } = "https://zenquotes.io/api";
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(10);
    public string? ApiKey { get; set; } // optional
}