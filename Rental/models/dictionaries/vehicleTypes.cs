namespace Rental.models;

public class VehicleType
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public string Level { get; init; } = string.Empty;
    public int Income { get; init; }
    public int Price { get; init; }
}