namespace Rental.WebApi.DTOs;

public class BuyVehicleRequestDto
{
    public int VehicleTypeId { get; set; }
    public string? CustomName { get; set; }
}

public class BuyStorageRequestDto
{
    public int StorageTypeId { get; set; }
}