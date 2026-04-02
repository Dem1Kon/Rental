namespace Rental.models;

public class GarageType
{
    public int  Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Capacity { get; init; }
    public decimal Price { get; init; }
    public decimal MonthlyCosts { get; init; }
}