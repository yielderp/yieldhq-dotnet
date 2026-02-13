namespace YieldHQ.Client;

/// <summary>
/// Configuration options for the YieldHQ API client.
/// </summary>
public class YieldHQClientOptions
{
    /// <summary>
    /// Base URL of the YieldHQ ERP instance (e.g. "https://erp.example.com").
    /// </summary>
    public string BaseUrl { get; set; } = "";

    /// <summary>
    /// OAuth access token used for API authentication.
    /// </summary>
    public string AccessToken { get; set; } = "";

    /// <summary>
    /// Maximum number of automatic retries on transient failures (429, 5xx). Default is 3.
    /// </summary>
    public int MaxRetries { get; set; } = 3;

    /// <summary>
    /// HTTP request timeout. Default is 30 seconds.
    /// </summary>
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
}
