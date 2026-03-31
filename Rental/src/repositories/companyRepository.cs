using Microsoft.EntityFrameworkCore;
using Rental.db;
using Rental.models;

namespace Rental.repositories;

public interface ICompanyRepository
{
    Task<Company> GetCompanyAsync();
    Task SaveAsync();
}

public class CompanyRepository(Context context) : ICompanyRepository
{
    public async Task<Company> GetCompanyAsync()
    {
        return await context.Companies.Include(c => c.Vehicles).FirstAsync();
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
}