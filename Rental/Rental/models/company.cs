namespace Rental.models;

public class Company
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal Balance { get; set; } = 10000;

    public List<Vehicle> Vehicles { get; init; } = [];
    public List<Storage> Storages { get; init; } = [];

    public void BuyVehicle(Vehicle vehicle)
    {
        if (Balance < vehicle.Price) throw new InvalidOperationException("You dont have enough money!");

        vehicle.CompanyId = Id;
        vehicle.Company = this;
        Balance -= vehicle.Price;
        Vehicles.Add(vehicle);
    }

    public void SellVehicle(Vehicle vehicle)
    {
        if (!Vehicles.Contains(vehicle)) throw new InvalidOperationException("You don't have this vehicle!");

        Balance += vehicle.Price;
        Vehicles.Remove(vehicle);
    }

    public void BuyStorage(Storage storage)
    {
        if (Balance < storage.Price) throw new InvalidOperationException("You dont have enough money!");
        
        storage.CompanyId = Id;
        storage.Company = this;
        
        Balance -= storage.Price;
        Storages.Add(storage);
    }

    public void SellStorage(Storage storage)
    {
        if (!Storages.Contains(storage)) throw new InvalidOperationException("You don't have this storage!");
        if (storage.Vehicles.Any()) throw new InvalidOperationException("Cannot sell non-empty storage");
        Storages.Remove(storage); 
        Balance += storage.Price;
    }

    public decimal GetIncome()
    {
        decimal income = 0;

        foreach (var vehicle in Vehicles) income += vehicle.MonthlyIncome;

        return income;
    }   
}