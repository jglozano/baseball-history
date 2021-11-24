using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class PitchingRepository : IPitchingRepository
{
    private readonly BaseballStatsContext _context;

    public PitchingRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.Pitchings.Count());
    }

    public async Task<List<Pitching>> GetAll(int pageNumber, int pageSize) => await _context.Pitchings
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Pitching?> GetById(string playerId, string teamId, short yearId, string lgId, short stint)
    {
        return await _context.Pitchings.FirstOrDefaultAsync(e => e.PlayerId == playerId && e.YearId == yearId && e.LgId == lgId && e.TeamId == teamId && e.Stint == stint);
    }

    public async Task<List<Pitching>> GetByPlayerId(string playerId)
    {
        return await _context.Pitchings.Where(e => e.PlayerId == playerId).ToListAsync();
    }
}