namespace Rental.models;

public class Vehicle
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid CompanyId { get; set; }
    public Guid GarageId { get; set; }
    public Company? Company { get; set; }


    public string Name { get; init; } = string.Empty;
    public DateTime PurchaseDate { get; init; } = DateTime.UtcNow;

    public int Price { get; set; } = 0;
    public int Income { get; init; } = 0;
}