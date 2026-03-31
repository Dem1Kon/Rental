using Microsoft.Extensions.Logging;
using Rental.models;
using Rental.repositories;

namespace Rental.services;

public interface ICompanyService
{
    Task<CompanyDto?> GetCompanyAsync();
    Task<bool> BuyVehicleAsync(BuyVehicleRequest vehicle);
    Task<bool> SellVehicleAsync(BuyVehicleRequest vehicle);
    Task<decimal> GetTotalIncomeAsync();
}

public abstract class BuyVehicleRequest
{
    public Guid Id { get; set; }
}

public class CompanyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Balance{get;set;}
    public decimal TotalIncome{get;set;}
}

public class CompanyService(
    ILogger<CompanyService> logger,
    IVehicleRepository vehicleRepository,
    ICompanyRepository repository)
    : ICompanyService
{
    private readonly ICompanyRepository _repository = repository;
    private readonly ILogger<CompanyService> _logger = logger;
    private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

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
            TotalIncome = company.GetIncome()
        };
    }

    public async Task<bool> BuyVehicleAsync(BuyVehicleRequest request)
    {
        var company = await _repository.GetCompanyAsync();
        if (company == null)
        {
            _logger.LogWarning("Company not found");
            return false;
        }
        
        var vehicle = _vehicleRepository.GetByIdAsync(request.Id).Result;
        if (vehicle == null)
        {
            _logger.LogWarning("Vehicle not found");
            return false;
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

    public async Task<bool> SellVehicleAsync(BuyVehicleRequest request)
    {
        var company = await _repository.GetCompanyAsync();
        if (company == null)
        {
            _logger.LogWarning("Company not found");
            return false;
        }

        var vehicle = _vehicleRepository.GetByIdAsync(request.Id).Result;
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