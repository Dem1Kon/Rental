namespace Rental.models;

public class Garage
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid CompanyId { get; set; } = Guid.Empty;

    public string Name { get; init; } = string.Empty;
    public List<Vehicle> Vehicles { get; init; } = [];
    public Company? Company { get; init; }


    public DateTime PurchaseDate { get; init; } = DateTime.UtcNow;

    public int Capacity { get; set; } = 10;
    public int Price { get; set; } = 5000;
    public int Costs { get; set; } = 500;
}