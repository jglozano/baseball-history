using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class PitchingRepository : IPitchingRepository
{
    private readonly BaseballStatsContext _context;

    public PitchingRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Pitching>> GetAll() => await _context.Pitchings.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Pitching?> GetById(string playerId, string teamId, short yearId, string lgId, short stint)
    {
        return await _context.Pitchings.FindAsync(playerId, teamId, yearId, lgId, stint);
    }
}