using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class BattingRepository : IBattingRepository
{
    private readonly BaseballStatsContext _context;

    public BattingRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.Battings.Count());
    }

    public async Task<List<Batting>> GetAll(int pageNumber, int pageSize) => await _context.Battings
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Batting?> GetById(string playerId, string teamId, short yearId, string lgId, short stint)
    {
        return await _context.Battings.FindAsync(playerId, teamId, yearId, lgId, stint);
    }
}