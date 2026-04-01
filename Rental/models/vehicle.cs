namespace Rental.models;

public class Vehicle
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public Guid CompanyId { get; init; }
    public Company Company { get; init; }
    
    public Guid GarageId { get; init; }
    public Garage Garage { get; init; }
    
    public required int TypeId { get; init; }
    public VehicleType Type { get; init; }

    public int Price { get; init; }
    public int Income { get; init; }
    public DateTime PurchaseDate { get; init; } = DateTime.UtcNow;
}