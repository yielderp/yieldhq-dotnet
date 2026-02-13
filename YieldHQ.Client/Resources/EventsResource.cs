using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Events;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Events API.</summary>
public class EventsResource : ResourceBase
{
    internal EventsResource(HttpClient http) : base(http) { }

    /// <summary>List events.</summary>
    public Task<PagedResult<Event>> ListAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Event>("/api/v1/events", query, ct);

    /// <summary>Get a single event by ID.</summary>
    public Task<Event> GetAsync(int id, CancellationToken ct = default) =>
        GetAsync<Event>($"/api/v1/events/{id}", ct);

    /// <summary>Create a new event.</summary>
    public Task<int> CreateAsync(Event ev, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/events", ev, ct);

    /// <summary>Update an existing event.</summary>
    public Task UpdateAsync(int id, Event ev, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/events/{id}", ev, ct);

    // Registrations
    /// <summary>List registrations for an event.</summary>
    public Task<PagedResult<EventRegistration>> ListRegistrationsAsync(int eventId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<EventRegistration>($"/api/v1/events/{eventId}/registrations", query, ct);

    /// <summary>Create a registration for an event.</summary>
    public Task<int> CreateRegistrationAsync(int eventId, EventRegistration registration, CancellationToken ct = default) =>
        CreateAsync<int>($"/api/v1/events/{eventId}/registrations", registration, ct);

    /// <summary>Confirm a registration.</summary>
    public Task ConfirmRegistrationAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/events/registrations/{id}/confirm", ct: ct);

    /// <summary>Cancel a registration.</summary>
    public Task CancelRegistrationAsync(int id, CancellationToken ct = default) =>
        ActionAsync($"/api/v1/events/registrations/{id}/cancel", ct: ct);

    // Tickets
    /// <summary>List tickets for an event.</summary>
    public Task<PagedResult<EventTicket>> ListTicketsAsync(int eventId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<EventTicket>($"/api/v1/events/{eventId}/tickets", query, ct);

    /// <summary>Create a ticket type for an event.</summary>
    public Task<int> CreateTicketAsync(int eventId, EventTicket ticket, CancellationToken ct = default) =>
        CreateAsync<int>($"/api/v1/events/{eventId}/tickets", ticket, ct);

    // Booths
    /// <summary>List booths for an event.</summary>
    public Task<PagedResult<EventBooth>> ListBoothsAsync(int eventId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<EventBooth>($"/api/v1/events/{eventId}/booths", query, ct);

    // Stages
    /// <summary>List event stages.</summary>
    public Task<PagedResult<EventStage>> ListStagesAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<EventStage>("/api/v1/events/stages", query, ct);
}
