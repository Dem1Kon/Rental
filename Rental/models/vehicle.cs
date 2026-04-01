namespace Rental.models;

public class Vehicle
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    public Guid CompanyId { get; set; }
    public Company Company { get; set; }
    
    public Guid GarageId { get; set; }
    public Garage Garage { get; set; }
    
    public required int TypeId { get; init; }
    public VehicleType Type { get; init; }

    public string Name { get; init; }
    public decimal Price { get; init; }
    public decimal Income { get; init; }
    public DateTime PurchaseDate { get; init; } = DateTime.UtcNow;
}