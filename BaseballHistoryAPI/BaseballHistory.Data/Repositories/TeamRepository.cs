using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly BaseballStatsContext _context;

    public TeamRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<Team>> GetAll() => await _context.Teams.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Team?> GetById(string teamId, short yearId, string lgId)
    {
        return await _context.Teams.FindAsync(teamId, yearId, lgId);
    }
}