/*using Rental.models;

namespace Rental.services;

public class VehicleDto
{
    public Guid Id { get; set; }
    public Guid GarageId { get; set; }
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public int Income { get; set; }
}

public interface IVehicleService
{
    Task<VehicleDto?> GetVehicleAsync();
    Task<VehicleDto?> GetVehicleAsync(Guid id);
    Task<List<VehicleDto>> GetAllVehiclesAsync();
    Task<>
    
}

public class VehicleService : IVehicleService
{
    
}*/