using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ITeamBattingTotalRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<TeamBattingTotal>> GetAll(int pageNumber, int pageSize);
    Task<TeamBattingTotal?> GetById(string teamId, short yearId, string lgId);
    Task<List<TeamBattingTotal>> GetByTeamId(string teamId);
}