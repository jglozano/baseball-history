using BaseballHistory.Data;
using BaseballHistory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Domain.Repositories;

public class CollegePlayingRepository : ICollegePlayingRepository
{
    private readonly BaseballStatsContext _context;

    public CollegePlayingRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public async Task<List<CollegePlaying>> GetAll() => await _context.CollegePlayings.AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<CollegePlaying?> GetById(string playerId, short yearId, string schoolId)
    {
        return await _context.CollegePlayings.FindAsync(playerId, yearId, schoolId);
    }
}