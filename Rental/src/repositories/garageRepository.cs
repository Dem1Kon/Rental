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
    public void Add(Garage garage)
    {
        context.Garages.Add(garage);
    }

    public void Update(Garage garage)
    {
        context.Garages.Update(garage);
    }

    public void Delete(Garage garage)
    {
        context.Garages.Remove(garage);
    }

    public async Task<List<Garage>> GetGaragesAsync()
    {
        return await context.Garages.AsNoTracking().ToListAsync();
    }

    public async Task<Garage?> GetGarageByIdAsync(Guid garageId)
    {
        return await context.Garages.FindAsync(garageId);
    }

    public async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
}