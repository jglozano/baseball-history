using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class HallOfFameRepository : IHallOfFameRepository
{
    private readonly BaseballStatsContext _context;

    public HallOfFameRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.HallOfFames.Count());
    }

    public async Task<List<HallOfFame>> GetAll(int pageNumber, int pageSize) => await _context.HallOfFames
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<HallOfFame?> GetById(string playerId, short yearId, string votedBy)
    {
        return await _context.HallOfFames.FindAsync(playerId, yearId, votedBy);
    }
}