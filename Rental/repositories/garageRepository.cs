using Microsoft.EntityFrameworkCore;
using Rental.db;
using Rental.models;

namespace Rental.repositories;

public interface IGarageRepository
{
    Task<List<Garage>> GetGaragesAsync();
    Task CreateGarageAsync(Garage garage);
    Task EditGarageAsync(Garage garage);
    Task RemoveGarageAsync(Garage garage);
    Task<Garage> GetGarageByIdAsync(int garageId);
    Task SaveGarageAsync();
}


public class GarageRepository(Context context) : IGarageRepository
{
    private readonly Context _context = context;

    public async Task CreateGarageAsync(Garage garage)
    {
        try
        {
            await _context.Garages.AddAsync(garage);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task EditGarageAsync(Garage garage)
    {
        try
        {
            _context.Garages.Update(garage);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task RemoveGarageAsync(Garage garage)
    {
        try
        {
            _context.Garages.Remove(garage);
            return _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Garage>> GetGaragesAsync()
    {
        return await _context.Garages.AsNoTracking().ToListAsync() ?? throw new Exception("No Garages found");
    }

    public async Task<Garage> GetGarageByIdAsync(int garageId)
    {
        return await _context.Garages.FindAsync(garageId) ?? throw new KeyNotFoundException();
    }

    public async Task SaveGarageAsync()
    {
        await _context.SaveChangesAsync();
    }
}