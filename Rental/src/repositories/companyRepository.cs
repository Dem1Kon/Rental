using Microsoft.EntityFrameworkCore;
using Rental.db;
using Rental.models;

namespace Rental.repositories;

public interface ICompanyRepository
{
    Task<Company?> GetCompanyAsync();
    Task SaveAsync();
}

public class CompanyRepository(Context context) : ICompanyRepository
{
    private readonly Context _context = context;
    
    public async Task<Company?> GetCompanyAsync()
    {
        return await _context.Companies
            .Include(c => c.Vehicles)
            .Include(c => c.Storages)
            .FirstOrDefaultAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}