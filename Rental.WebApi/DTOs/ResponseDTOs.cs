namespace Rental.WebApi.DTOs;

public class CompanyResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public int VehiclesCount { get; set; }
    public int StoragesCount { get; set; }
    public decimal TotalMonthlyIncome { get; set; }
}

public class VehicleResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal MonthlyIncome { get; set; }
    public string TypeName { get; set; } = string.Empty;
    public string TypeCategory { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }
}

public class StorageResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public int OccupiedSlots { get; set; }
    public decimal Price { get; set; }
    public decimal MonthlyCosts { get; set; }
    public DateTime PurchaseDate { get; set; }
}

public class VehicleTypeResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Level { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal MonthlyIncome { get; set; }
    public string RequiredStorageCategory { get; set; } = string.Empty;
}

public class StorageTypeResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public decimal Price { get; set; }
    public decimal MonthlyCosts { get; set; }
}