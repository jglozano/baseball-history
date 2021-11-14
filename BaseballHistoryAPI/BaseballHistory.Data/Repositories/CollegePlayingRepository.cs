using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class CollegePlayingRepository : ICollegePlayingRepository
{
    private readonly BaseballStatsContext _context;

    public CollegePlayingRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.CollegePlayings.Count());
    }

    public async Task<List<CollegePlaying>> GetAll(int pageNumber, int pageSize) => await _context.CollegePlayings
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<CollegePlaying?> GetById(string playerId, short yearId, string schoolId)
    {
        return await _context.CollegePlayings.FindAsync(playerId, yearId, schoolId);
    }
}