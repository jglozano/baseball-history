using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class SeriesPostRepository : ISeriesPostRepository
{
    private readonly BaseballStatsContext _context;

    public SeriesPostRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<SeriesPost>> GetAll() => await _context.SeriesPosts.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<SeriesPost?> GetById(string teamIdwinner, string lgIdwinner, short yearId, string round)
    {
        return await _context.SeriesPosts.FindAsync(teamIdwinner, lgIdwinner, yearId, round);
    }
}