namespace Rental.models;

public class Storage
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid CompanyId { get; set; } = Guid.Empty;
    public required int TypeId { get; init; }
    public required StorageType StorageType { get; init; }

    public DateTime PurchaseDate { get; init; } = DateTime.UtcNow;

    public int Capacity { get; init; }
    public decimal Price { get; init; }
    public decimal MonthlyCosts { get; init; }
    
    public List<Vehicle> Vehicles { get; init; } = [];
    
    public Company Company { get; set; }
}