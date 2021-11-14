using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseballHistory.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly BaseballStatsContext _context;

    public PersonRepository(BaseballStatsContext context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public Task<int> GetTotalCount()
    {
        return Task.FromResult(_context.People.Count());
    }

    public async Task<List<Person>> GetAll(int pageNumber, int pageSize) => await _context.People
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .AsNoTrackingWithIdentityResolution().ToListAsync();
    public async Task<Person?> GetById(string playerId)
    {
        return await _context.People.FindAsync(playerId);
    }
}