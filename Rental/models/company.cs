namespace Rental.models;

public class Company
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Balance { get; set; } = 10000;

    public List<Vehicle> Vehicles { get; init; } = [];
    public List<Garage> Garages { get; init; } = [];

    public void BuyVehicle(Vehicle vehicle)
    {
        if (Balance < vehicle.Price) throw new InvalidOperationException("You dont have enough money!");

        Balance -= vehicle.Price;
        Vehicles.Add(vehicle);
    }

    public void SellVehicle(Vehicle vehicle)
    {
        if (!Vehicles.Contains(vehicle)) throw new InvalidOperationException("You don't have this vehicle!");

        Balance += vehicle.Price;
        Vehicles.Remove(vehicle);
    }

    public decimal GetIncome()
    {
        var income = 0;

        foreach (var vehicle in Vehicles) income += vehicle.Income;

        return income;
    }
}