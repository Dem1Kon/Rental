namespace Rental.models;

public class Company
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal Balance { get; set; } = 10000;

    public List<Vehicle> Vehicles { get; init; } = [];
    public List<Garage> Garages { get; init; } = [];

    public void BuyVehicle(Vehicle vehicle)
    {
        if(vehicle.Id != Guid.Empty) throw new InvalidOperationException("Vehicle already exists in company!");
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

    public void BuyGarage(Garage garage)
    {
        if(garage.CompanyId != Guid.Empty) throw new InvalidOperationException("Garage already exists in company!");
        if (Balance < garage.Price) throw new InvalidOperationException("You dont have enough money!");
        
        garage.CompanyId = Id;
        garage.Company = this;
        
        Balance -= garage.Price;
        Garages.Add(garage);
    }

    public void SellGarage(Garage garage)
    {
        if (!Garages.Contains(garage)) throw new InvalidOperationException("You don't have this garage!");
        Garages.Remove(garage); 
        Balance += garage.Price;
    }

    public decimal GetIncome()
    {
        decimal income = 0;

        foreach (var vehicle in Vehicles) income += vehicle.Income;

        return income;
    }
}