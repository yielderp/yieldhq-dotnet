using YieldHQ.Client.Models;
using YieldHQ.Client.Models.Fleet;

namespace YieldHQ.Client.Resources;

/// <summary>Provides access to the Fleet API.</summary>
public class FleetResource : ResourceBase
{
    internal FleetResource(HttpClient http) : base(http) { }

    // Vehicles
    /// <summary>List vehicles.</summary>
    public Task<PagedResult<Vehicle>> ListVehiclesAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<Vehicle>("/api/v1/fleet/vehicles", query, ct);

    /// <summary>Get a single vehicle by ID.</summary>
    public Task<Vehicle> GetVehicleAsync(int id, CancellationToken ct = default) =>
        GetAsync<Vehicle>($"/api/v1/fleet/vehicles/{id}", ct);

    /// <summary>Create a new vehicle.</summary>
    public Task<int> CreateVehicleAsync(Vehicle vehicle, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/fleet/vehicles", vehicle, ct);

    /// <summary>Update a vehicle.</summary>
    public Task UpdateVehicleAsync(int id, Vehicle vehicle, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/fleet/vehicles/{id}", vehicle, ct);

    // Fuel Logs
    /// <summary>List fuel logs for a vehicle.</summary>
    public Task<PagedResult<FuelLog>> ListFuelLogsAsync(int vehicleId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<FuelLog>($"/api/v1/fleet/vehicles/{vehicleId}/fuel-logs", query, ct);

    /// <summary>Create a fuel log entry.</summary>
    public Task<int> CreateFuelLogAsync(int vehicleId, FuelLog fuelLog, CancellationToken ct = default) =>
        CreateAsync<int>($"/api/v1/fleet/vehicles/{vehicleId}/fuel-logs", fuelLog, ct);

    // Service Logs
    /// <summary>List service logs for a vehicle.</summary>
    public Task<PagedResult<ServiceLog>> ListServiceLogsAsync(int vehicleId, QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<ServiceLog>($"/api/v1/fleet/vehicles/{vehicleId}/service-logs", query, ct);

    /// <summary>Create a service log entry.</summary>
    public Task<int> CreateServiceLogAsync(int vehicleId, ServiceLog serviceLog, CancellationToken ct = default) =>
        CreateAsync<int>($"/api/v1/fleet/vehicles/{vehicleId}/service-logs", serviceLog, ct);

    // Contracts
    /// <summary>List contracts, optionally filtered by vehicle.</summary>
    public Task<PagedResult<VehicleContract>> ListContractsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<VehicleContract>("/api/v1/fleet/contracts", query, ct);

    /// <summary>Create a new contract.</summary>
    public Task<int> CreateContractAsync(VehicleContract contract, CancellationToken ct = default) =>
        CreateAsync<int>("/api/v1/fleet/contracts", contract, ct);

    /// <summary>Update a contract.</summary>
    public Task UpdateContractAsync(int id, VehicleContract contract, CancellationToken ct = default) =>
        UpdateAsync($"/api/v1/fleet/contracts/{id}", contract, ct);

    // Brands & Models
    /// <summary>List vehicle brands.</summary>
    public Task<PagedResult<VehicleBrand>> ListBrandsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<VehicleBrand>("/api/v1/fleet/brands", query, ct);

    /// <summary>List vehicle models, optionally filtered by brand.</summary>
    public Task<PagedResult<VehicleModel>> ListModelsAsync(QueryParams? query = null, CancellationToken ct = default) =>
        ListAsync<VehicleModel>("/api/v1/fleet/models", query, ct);
}
