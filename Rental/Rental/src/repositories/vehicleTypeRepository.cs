using Rental.db;
using Rental.models;

namespace Rental.repositories;

public interface IVehicleTypeRepository
{
    Task<VehicleType?> GetVehicleTypeAsync(int vehicleTypeId);
}

public class VehicleTypeRepository(Context context):IVehicleTypeRepository
{
    private readonly Context _context = context;
    
    public async Task<VehicleType?> GetVehicleTypeAsync(int vehicleTypeId)
    {
        return await _context.VehicleTypes.FindAsync(vehicleTypeId);
    }
}