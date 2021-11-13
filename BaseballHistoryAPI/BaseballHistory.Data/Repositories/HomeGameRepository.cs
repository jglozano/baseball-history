using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class HomeGameRepository : IHomeGameRepository
{
    private readonly BaseballStatsContext _context;

    public HomeGameRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<HomeGame>> GetAll() => await _context.HomeGames.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<HomeGame?> GetById(string teamId, string lgId, short yearId, string parkId)
    {
        return await _context.HomeGames.FindAsync(teamId, lgId, yearId, parkId);
    }
}