using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class TeamsFranchiseRepository : ITeamsFranchiseRepository
{
    private readonly BaseballStatsContext _context;

    public TeamsFranchiseRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.TeamsFranchises.Count());
    }

    public async Task<List<TeamsFranchise>> GetAll(int pageNumber, int pageSize) => await _context.TeamsFranchises
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<TeamsFranchise?> GetById(string franchId)
    {
        return await _context.TeamsFranchises.FirstOrDefaultAsync(e => e.FranchId == franchId);
    }
}