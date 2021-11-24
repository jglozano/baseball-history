using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class PlayerFieldingTotalRepository : IPlayerFieldingTotalRepository
{
    private readonly BaseballStatsContext _context;

    public PlayerFieldingTotalRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.PlayerFieldingTotals.Count());
    }

    public async Task<List<PlayerFieldingTotal>> GetAll(int pageNumber, int pageSize) => await _context.PlayerFieldingTotals
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<PlayerFieldingTotal?> GetById(string playerId)
    {
        return await _context.PlayerFieldingTotals.FirstOrDefaultAsync(p => p.PlayerId == playerId);
    }
}