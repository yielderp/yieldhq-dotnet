using System.Security.Cryptography;
using System.Text;

namespace YieldHQ.Client.Webhooks;

/// <summary>
/// Validates incoming webhook signatures using HMAC-SHA256.
/// </summary>
public static class WebhookValidator
{
    /// <summary>
    /// Validates that a webhook payload matches the provided signature using the shared secret.
    /// Uses a timing-safe comparison to prevent timing attacks.
    /// </summary>
    /// <param name="payload">The raw request body string.</param>
    /// <param name="signature">The signature from the X-Webhook-Signature header.</param>
    /// <param name="secret">The shared webhook secret.</param>
    /// <returns>True if the signature is valid.</returns>
    public static bool Validate(string payload, string signature, string secret)
    {
        var secretBytes = Encoding.UTF8.GetBytes(secret);
        var payloadBytes = Encoding.UTF8.GetBytes(payload);

        var hash = HMACSHA256.HashData(secretBytes, payloadBytes);
        var computed = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();

        return CryptographicOperations.FixedTimeEquals(
            Encoding.UTF8.GetBytes(computed),
            Encoding.UTF8.GetBytes(signature));
    }
}
