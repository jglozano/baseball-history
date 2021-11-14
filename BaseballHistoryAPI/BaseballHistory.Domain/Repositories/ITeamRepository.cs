using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ITeamRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<Team>> GetAll(int pageNumber, int pageSize);
    Task<Team?> GetById(string teamId, short yearId, string lgId);
}