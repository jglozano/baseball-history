using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class FieldingOfRepository : IFieldingOfRepository
{
    private readonly BaseballStatsContext _context;

    public FieldingOfRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.FieldingOfs.Count());
    }

    public async Task<List<FieldingOf>> GetAll(int pageNumber, int pageSize) => await _context.FieldingOfs
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<FieldingOf?> GetById(string playerId, short yearId, short stint)
    {
        return await _context.FieldingOfs.FindAsync(playerId, yearId, stint);
    }
}