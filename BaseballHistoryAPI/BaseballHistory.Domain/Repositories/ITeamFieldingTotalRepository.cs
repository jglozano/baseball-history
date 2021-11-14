using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ITeamFieldingTotalRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<TeamFieldingTotal>> GetAll(int pageNumber, int pageSize);
    Task<TeamFieldingTotal?> GetById(string teamId, short yearId, string lgId);
}