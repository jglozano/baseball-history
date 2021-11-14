using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class HomeGameRepository : IHomeGameRepository
{
    private readonly BaseballStatsContext _context;

    public HomeGameRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.HomeGames.Count());
    }

    public async Task<List<HomeGame>> GetAll(int pageNumber, int pageSize) => await _context.HomeGames
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<HomeGame?> GetById(string teamId, string lgId, short yearId, string parkId)
    {
        return await _context.HomeGames.FindAsync(teamId, lgId, yearId, parkId);
    }
}