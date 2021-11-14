using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ITeamPitchingTotalRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<TeamPitchingTotal>> GetAll(int pageNumber, int pageSize);
    Task<TeamPitchingTotal?> GetById(string teamId, short yearId, string lgId);
}