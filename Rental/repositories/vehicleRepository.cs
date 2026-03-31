using Microsoft.EntityFrameworkCore;
using Rental.db;
using Rental.models;

namespace Rental.repositories;

public interface IVehicleRepository
{
    void Add(Vehicle vehicle);
    void Update(Vehicle vehicle);
    void Remove(Vehicle vehicle);
    Task<Vehicle?> GetByIdAsync(Guid id);
    Task<List<Vehicle>> GetAllAsync();
    Task SaveChangesAsync();
}

public class VehicleRepository(Context context) : IVehicleRepository
{
    public void Add(Vehicle vehicle)
    {
        context.Vehicles.Add(vehicle);
    }

    public void Update(Vehicle vehicle)
    {
        context.Vehicles.Update(vehicle);
    }

    public void Remove(Vehicle vehicle)
    {
        context.Vehicles.Remove(vehicle);
    }

    public async Task<Vehicle?> GetByIdAsync(Guid id)
    {
        return await context.Vehicles.FindAsync(id);
    }

    public async Task<List<Vehicle>> GetAllAsync()
    {
        return await context.Vehicles.ToListAsync();
    }
    
    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}