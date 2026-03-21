namespace Rental.models;

public class Car : Vehicle
{

    public Car Economy() => new()
    {
        Price = 10000,
        Income = 1000,
        Name = "Economy car"
    };

    public Car Comfort() => new()
    {
        Price = 50000,
        Income = 5000,
        Name = "Comfort car"
    };

    public Car Business() => new()
    {
        Price = 100000,
        Income = 10000,
        Name = "Business car"
    };
    
    public override string ToString() => $"{Name}, Price: {Price}, Income: {Income}";
}