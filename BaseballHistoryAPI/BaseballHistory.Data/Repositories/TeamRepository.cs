using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly BaseballStatsContext _context;

    public TeamRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.Teams.Count());
    }

    public async Task<List<Team>> GetAll(int pageNumber, int pageSize) => await _context.Teams
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Team?> GetById(string teamId, short yearId, string lgId)
    {
        return await _context.Teams.FirstOrDefaultAsync(e => e.TeamId == teamId && e.YearId == yearId && e.LgId == lgId);
    }

    public async Task<List<Team>> GetTeamByFranchId(string franchId)
    {
        return await _context.Teams.Where(e => e.FranchId == franchId).ToListAsync();
    }
}