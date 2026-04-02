using Rental.db;
using Rental.models;

namespace Rental.repositories;

public interface IStorageTypeRepository
{
    Task<StorageType?> GetStorageTypeByIdAsync(int vehicleTypeId);
}

public class StorageTypeRepository(Context context) : IStorageTypeRepository
{
    private readonly Context _context = context;

    public async Task<StorageType?> GetStorageTypeByIdAsync(int storageTypeId)
    {
        return await _context.StorageTypes.FindAsync(storageTypeId);
    }
}