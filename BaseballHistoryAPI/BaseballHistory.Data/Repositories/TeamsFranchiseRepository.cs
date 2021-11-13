using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class TeamsFranchiseRepository : ITeamsFranchiseRepository
{
    private readonly BaseballStatsContext _context;

    public TeamsFranchiseRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<TeamsFranchise>> GetAll() => await _context.TeamsFranchises.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<TeamsFranchise?> GetById(string franchId)
    {
        return await _context.TeamsFranchises.FindAsync(franchId);
    }
}