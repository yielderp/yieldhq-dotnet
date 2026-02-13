namespace YieldHQ.Client.Webhooks;

/// <summary>
/// Represents a webhook event payload received from the YieldHQ ERP.
/// </summary>
/// <typeparam name="T">The type of the event data.</typeparam>
public class WebhookPayload<T>
{
    /// <summary>The event type identifier (e.g. "sale.order.confirmed").</summary>
    public string Event { get; set; } = "";

    /// <summary>The event data payload.</summary>
    public T? Data { get; set; }

    /// <summary>UTC timestamp when the event was dispatched.</summary>
    public DateTime Timestamp { get; set; }

    /// <summary>Unique identifier for the webhook delivery.</summary>
    public string WebhookId { get; set; } = "";
}
