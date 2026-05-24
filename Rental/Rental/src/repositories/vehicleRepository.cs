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
    Task SaveAsync();
}

public class VehicleRepository(Context context) : IVehicleRepository
{
    private readonly Context _context = context;
    
    public void Add(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
    }

    public void Update(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
    }

    public void Remove(Vehicle vehicle)
    {
        _context.Vehicles.Remove(vehicle);
    }

    public async Task<Vehicle?> GetByIdAsync(Guid id)
    {
        return await _context.Vehicles.FindAsync(id);
    }

    public async Task<List<Vehicle>> GetAllAsync()
    {
        return await _context.Vehicles.AsNoTracking().ToListAsync();
    }
    
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}