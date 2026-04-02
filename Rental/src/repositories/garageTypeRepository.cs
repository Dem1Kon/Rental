using Rental.db;
using Rental.models;

namespace Rental.repositories;

public interface IGarageTypeRepository
{
    Task<GarageType?> GetGarageTypeByIdAsync(int vehicleTypeId);
}

public class garageTypeRepository(Context context) : IGarageTypeRepository
{
    private readonly Context _context = context;

    public async Task<GarageType?> GetGarageTypeByIdAsync(int garageTypeId)
    {
        return await _context.GarageTypes.FindAsync(garageTypeId);
    }
}