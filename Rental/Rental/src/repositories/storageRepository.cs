using Microsoft.EntityFrameworkCore;
using Rental.db;
using Rental.models;

namespace Rental.repositories;

public interface IStorageRepository
{
    Task<List<Storage>> GetStoragesAsync();
    void Add(Storage storage);
    void Update(Storage storage);
    void Delete(Storage storage);
    Task<Storage?> GetStorageByIdAsync(Guid storageId);
    Task SaveAsync();
}

public class StorageRepository(Context context) : IStorageRepository
{
    private readonly Context _context = context;
    public void Add(Storage storage)
    {
        _context.Storages.Add(storage);
    }

    public void Update(Storage storage)
    {
        _context.Storages.Update(storage);
    }

    public void Delete(Storage storage)
    {
        _context.Storages.Remove(storage);
    }

    public async Task<List<Storage>> GetStoragesAsync()
    {
        return await _context.Storages.AsNoTracking().ToListAsync();
    }

    public async Task<Storage?> GetStorageByIdAsync(Guid storageId)
    {
        return await _context.Storages.FindAsync(storageId);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}