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
    Task<Garage?> GetGarageByIdAsync(Guid garageId);
    Task SaveAsync();
}

public class GarageRepository(Context context) : IGarageRepository
{
    private readonly Context _context = context;
    public void Add(Garage garage)
    {
        _context.Garages.Add(garage);
    }

    public void Update(Garage garage)
    {
        _context.Garages.Update(garage);
    }

    public void Delete(Garage garage)
    {
        _context.Garages.Remove(garage);
    }

    public async Task<List<Garage>> GetGaragesAsync()
    {
        return await _context.Garages.AsNoTracking().ToListAsync();
    }

    public async Task<Garage?> GetGarageByIdAsync(Guid garageId)
    {
        return await _context.Garages.FindAsync(garageId);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}