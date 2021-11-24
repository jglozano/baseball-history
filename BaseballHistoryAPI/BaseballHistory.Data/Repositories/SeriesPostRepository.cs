using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class SeriesPostRepository : ISeriesPostRepository
{
    private readonly BaseballStatsContext _context;

    public SeriesPostRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.SeriesPosts.Count());
    }

    public async Task<List<SeriesPost>> GetAll(int pageNumber, int pageSize) => await _context.SeriesPosts
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<SeriesPost?> GetById(string teamIdwinner, string lgIdwinner, short yearId, string round)
    {
        return await _context.SeriesPosts.FirstOrDefaultAsync(e => e.TeamIdwinner == teamIdwinner && e.LgIdwinner == lgIdwinner && e.YearId == yearId && e.Round == round);
    }

    public async Task<List<SeriesPost>> GetByTeamId(string teamId)
    {
        return await _context.SeriesPosts.Where(e => e.TeamIdwinner == teamId).ToListAsync();
    }
}