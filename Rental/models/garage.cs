namespace Rental.models;

public class Garage
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid CompanyId { get; set; } = Guid.Empty;
    public int TypeId { get; set; }

    public DateTime PurchaseDate { get; init; } = DateTime.UtcNow;

    public int Capacity { get; init; }
    public decimal Price { get; init; }
    public decimal Costs { get; init; }
    
    public List<Vehicle> Vehicles { get; init; } = [];
    public GarageType GarageType { get; init; }
    public Company Company { get; set; }

    public void AddVehicle(Vehicle vehicle)
    {
        if(Vehicles.Count < Capacity)
        {
            Vehicles.Add(vehicle);
            vehicle.Garage = this;
            vehicle.GarageId = Id;
        }
        else
        {
            throw new Exception("You can't add more vehicles! Garage is full!");
        }
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        if (Vehicles.Contains(vehicle))
        {
            Vehicles.Remove(vehicle);
            vehicle.Garage = null;
            vehicle.GarageId = Guid.Empty;
        }
        else
        {
            throw new Exception("You can't remove this vehicle! Garage doesn't have it");
        }
    }
}