using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ITeamsHalfRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<TeamsHalf>> GetAll(int pageNumber, int pageSize);
    Task<TeamsHalf?> GetById(string teamId, short yearId, string lgId, string half);
    Task<List<TeamsHalf>> GetByTeamId(string teamId);
}