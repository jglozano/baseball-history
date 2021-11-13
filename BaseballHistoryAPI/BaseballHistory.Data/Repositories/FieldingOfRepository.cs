using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class FieldingOfRepository : IFieldingOfRepository
{
    private readonly BaseballStatsContext _context;

    public FieldingOfRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<FieldingOf>> GetAll() => await _context.FieldingOfs.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<FieldingOf?> GetById(string playerId, short yearId, short stint)
    {
        return await _context.FieldingOfs.FindAsync(playerId, yearId, stint);
    }
}