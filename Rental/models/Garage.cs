namespace Rental.models;

public class Garage
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid CompanyId { get; set; } = Guid.Empty;
    
    public string Name { get; init; } = String.Empty;
    public List<Vehicle> Vehicles { get; init; } = [];
    public Company? Company{get; init;}
   
    
    public DateTime PurchaseDate { get; init; } =  DateTime.UtcNow;

    public virtual int Capacity { get; set; } = 0;
    public virtual int Price { get; set; } = 0;
    public virtual int Costs { get; set; } = 0;
}