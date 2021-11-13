using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class HallOfFameRepository : IHallOfFameRepository
{
    private readonly BaseballStatsContext _context;

    public HallOfFameRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<HallOfFame>> GetAll() => await _context.HallOfFames.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<HallOfFame?> GetById(string playerId, short yearId, string votedBy)
    {
        return await _context.HallOfFames.FindAsync(playerId, yearId, votedBy);
    }
}