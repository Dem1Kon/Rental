using Microsoft.EntityFrameworkCore;
using Rental.db;
using Rental.models;

namespace Rental.repositories;

public interface IGarageRepository
{
    Task<List<Garage>> GetGaragesAsync();
    void Add(Garage garage);
    void Update(Garage garage);
    void Delete(Garage garage);
    Task<Garage> GetGarageByIdAsync(Guid garageId);
    Task SaveGarageAsync();
}

public class GarageRepository(Context context) : IGarageRepository
{
    private readonly Context _context = context;

    public void Add(Garage garage)
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

    public void Update(Garage garage)
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

    public void Delete(Garage garage)
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

    public async Task<Garage?> GetGarageByIdAsync(Guid garageId)
    {
        return await _context.Garages.FindAsync(garageId);
    }

    public async Task SaveGarageAsync()
    {
        await _context.SaveChangesAsync();
    }
}