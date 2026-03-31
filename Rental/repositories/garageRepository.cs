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
    public void Add(Garage garage)
    {
        try
        {
            context.Garages.AddAsync(garage);
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
            context.Garages.Update(garage);
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
            context.Garages.Remove(garage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Garage>> GetGaragesAsync()
    {
        return await context.Garages.AsNoTracking().ToListAsync();
    }

    public async Task<Garage?> GetGarageByIdAsync(Guid garageId)
    {
        return await context.Garages.FindAsync(garageId);
    }

    public async Task SaveGarageAsync()
    {
        await context.SaveChangesAsync();
    }
}