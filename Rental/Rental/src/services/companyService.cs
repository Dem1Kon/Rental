using Microsoft.Extensions.Logging;
using Rental.models;
using Rental.repositories;

namespace Rental.services;


public class CompanyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Balance{get;set;}
    public decimal MonthlyIncome{get;set;}
}

public class GarageInfoDto
{
    public int GaragesAmount { get; set; }
    public int GarageCapacity { get; set; }
    public int OccupiedAmount { get; set; }
    public int MonthlyCosts { get; set; }
}

public interface ICompanyService
{
    Task<CompanyDto?> GetCompanyAsync();
    Task<bool> BuyVehicleAsync(int vehicleTypeId);
    Task<bool> SellVehicleAsync(Guid vehicleId);
    Task<decimal> GetTotalIncomeAsync();
    Task<bool> BuyGarageAsync(int garageTypeId);
    Task<bool> SellGarageAsync(Guid garageId);
}



public class CompanyService(
    ILogger<CompanyService> logger,
    IVehicleTypeRepository vehicleTypeRepository,
    ICompanyRepository repository,
    IStorageTypeRepository storageTypeRepository)
    : ICompanyService
{
    private readonly ICompanyRepository _repository = repository;
    private readonly ILogger<CompanyService> _logger = logger;
    private readonly IVehicleTypeRepository _vehicleTypeRepository = vehicleTypeRepository;
    private readonly IStorageTypeRepository _storageTypeRepository = storageTypeRepository;

    public async Task<CompanyDto?> GetCompanyAsync()
    {
        var company = await _repository.GetCompanyAsync();
        if (company == null)
        {
            _logger.LogWarning("Company not found");
            return null;
        }
        
        return new CompanyDto
        {
            Id = company.Id,
            Name = company.Name,
            Balance = company.Balance,
            MonthlyIncome = company.GetIncome()
        };
    }

    public async Task<bool> BuyVehicleAsync(int typeId)
    {
        var company = await _repository.GetCompanyAsync();
        if (company == null)
        {
            _logger.LogWarning("Company not found");
            return false;
        }
        
        var vehicleType = await _vehicleTypeRepository.GetVehicleTypeAsync(typeId);
        if (vehicleType == null)
        {
            _logger.LogWarning("Vehicle type not found");
            return false;
        }

        var vehicle = new Vehicle
        {
            Price = vehicleType.Price,
            MonthlyIncome = vehicleType.MonthlyIncome,
            Type = vehicleType,
            TypeId = typeId
        };

        if (company.Storages.Any())
        {
            var freeGarage = company.Storages.FirstOrDefault(g => g.Vehicles.Count < g.Capacity);
            if (freeGarage != null)
            {
                vehicle.StorageId = freeGarage.Id;
            }
        }

        try
        {
            company.BuyVehicle(vehicle);
            await _repository.SaveAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogWarning(e.Message);
            return false;
        }
    }

    public async Task<bool> SellVehicleAsync(Guid vehicleId)
    {
        var company = await _repository.GetCompanyAsync();
        if (company == null)
        {
            _logger.LogWarning("Company not found");
            return false;
        }

        var vehicle = company.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
        if (vehicle == null)
        {
            _logger.LogWarning("Vehicle not found");
            return false;
        }
        
        try
        {
            company.SellVehicle(vehicle);
            await _repository.SaveAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogWarning(e.Message);
            return false;
        }
    }

    public async Task<bool> BuyGarageAsync(int garageTypeId)
    {
        var company = await _repository.GetCompanyAsync();
        if (company == null)
        {
            _logger.LogWarning("Company not found");
            return false;
        }

        var garageType = await _storageTypeRepository.GetStorageTypeByIdAsync(garageTypeId);
        if (garageType == null)
        {
            _logger.LogWarning("Garage type not found");
            return false;
        }

        var garage = new Storage
        {
            Capacity = garageType.Capacity,
            StorageType = garageType,
            TypeId = garageTypeId,
            MonthlyCosts = garageType.MonthlyCosts,
            Price = garageType.Price,
        };

        try
        {
            company.BuyStorage(garage);
            await _repository.SaveAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogWarning(e.Message);
            return false;
        }
    }

    public async Task<bool> SellGarageAsync(Guid garageId)
    {
        var company = await _repository.GetCompanyAsync();
        if (company == null)
        {
            _logger.LogWarning("Company not found");
            return false;
        }
        var garage = company.Storages.FirstOrDefault(g => g.Id == garageId);
        if (garage == null)
        {
            _logger.LogWarning("Garage not found");
            return false;
        }

        try
        {
            company.SellStorage(garage);
            await _repository.SaveAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogWarning(e.Message);
            return false;
        }
    }

    public async Task<decimal> GetTotalIncomeAsync()
    {
        var company = await _repository.GetCompanyAsync();
        if (company == null)
        {
            _logger.LogWarning("Company not found");
            return 0;
        }
        
        return company.GetIncome();
    }
}