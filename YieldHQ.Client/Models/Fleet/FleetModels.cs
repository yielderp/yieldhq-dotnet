namespace YieldHQ.Client.Models.Fleet;

/// <summary>Represents a fleet vehicle.</summary>
public class Vehicle
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public bool Active { get; set; } = true;
    public string? LicensePlate { get; set; }
    public string? VinSn { get; set; }
    public int? DriverId { get; set; }
    public int? ModelId { get; set; }
    public int? BrandId { get; set; }
    public int? StateId { get; set; }
    public int? CompanyId { get; set; }
    public string? Color { get; set; }
    public int Seats { get; set; }
    public int Doors { get; set; }
    public double Odometer { get; set; }
    public string OdometerUnit { get; set; } = "kilometers";
    public string? Transmission { get; set; }
    public string? FuelType { get; set; }
    public int Horsepower { get; set; }
    public double CarValue { get; set; }
    public DateTime? AcquisitionDate { get; set; }
    public string? Location { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a fuel log entry for a vehicle.</summary>
public class FuelLog
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public DateTime? Date { get; set; }
    public double Liter { get; set; }
    public double PricePerLiter { get; set; }
    public double Amount { get; set; }
    public double Odometer { get; set; }
    public int? VendorId { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a service log entry for a vehicle.</summary>
public class ServiceLog
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public DateTime? Date { get; set; }
    public string? Description { get; set; }
    public double Amount { get; set; }
    public double Odometer { get; set; }
    public int? VendorId { get; set; }
    public string? Notes { get; set; }
    public string State { get; set; } = "new";
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a vehicle contract (lease, insurance, etc.).</summary>
public class VehicleContract
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public string Name { get; set; } = "";
    public bool Active { get; set; } = true;
    public DateTime? StartDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public int? InsurerId { get; set; }
    public string State { get; set; } = "open";
    public double Amount { get; set; }
    public string CostFrequency { get; set; } = "monthly";
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a vehicle brand (manufacturer).</summary>
public class VehicleBrand
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public bool Active { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}

/// <summary>Represents a vehicle model.</summary>
public class VehicleModel
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int BrandId { get; set; }
    public bool Active { get; set; } = true;
    public string VehicleType { get; set; } = "car";
    public string? Transmission { get; set; }
    public int Seats { get; set; }
    public int Doors { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime WrittenAt { get; set; }
}
