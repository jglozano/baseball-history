using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ITeamsHalfRepository : IDisposable
{
    Task<List<TeamsHalf>> GetAll();
    Task<TeamsHalf?> GetById(string teamId, short yearId, string lgId, string half);
}