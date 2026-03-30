namespace Rental.models;

public class Car : Vehicle
{
    public Car Economy()
    {
        return new Car
        {
            Price = 10000,
            Income = 1000,
            Name = "Economy car"
        };
    }

    public Car Comfort()
    {
        return new Car
        {
            Price = 50000,
            Income = 5000,
            Name = "Comfort car"
        };
    }

    public Car Business()
    {
        return new Car
        {
            Price = 100000,
            Income = 10000,
            Name = "Business car"
        };
    }

    public override string ToString()
    {
        return $"{Name}, Price: {Price}, Income: {Income}";
    }
}