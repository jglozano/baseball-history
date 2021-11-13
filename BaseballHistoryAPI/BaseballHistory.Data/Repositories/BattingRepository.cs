using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class BattingRepository : IBattingRepository
{
    private readonly BaseballStatsContext _context;

    public BattingRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Batting>> GetAll() => await _context.Battings.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Batting?> GetById(string playerId, string teamId, short yearId, string lgId, short stint)
    {
        return await _context.Battings.FindAsync(playerId, teamId, yearId, lgId, stint);
    }
}