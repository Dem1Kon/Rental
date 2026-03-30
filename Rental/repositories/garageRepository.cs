using Microsoft.EntityFrameworkCore;
using Rental.db;
using Rental.models;

namespace Rental.repositories;

public interface IGarageRepository
{
    Task<List<Garage>> GetGaragesAsync();
    void CreateGarageAsync(Garage garage);
    void EditGarageAsync(Garage garage);
    void RemoveGarageAsync(Garage garage);
    Task<Garage> GetGarageByIdAsync(Guid garageId);
    Task SaveGarageAsync();
}

public class GarageRepository(Context context) : IGarageRepository
{
    private readonly Context _context = context;

    public void CreateGarageAsync(Garage garage)
    {
        try
        {
            _context.Garages.AddAsync(garage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void EditGarageAsync(Garage garage)
    {
        try
        {
            _context.Garages.Update(garage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void RemoveGarageAsync(Garage garage)
    {
        try
        {
            _context.Garages.Remove(garage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Garage>> GetGaragesAsync()
    {
        return await _context.Garages.AsNoTracking().ToListAsync();
    }

    public async Task<Garage> GetGarageByIdAsync(Guid garageId)
    {
        return await _context.Garages.FindAsync(garageId) ?? throw new KeyNotFoundException();
    }

    public async Task SaveGarageAsync()
    {
        await _context.SaveChangesAsync();
    }
}