using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ITeamBattingTotalRepository : IDisposable
{
    Task<List<TeamBattingTotal>> GetAll();
    Task<TeamBattingTotal?> GetById(string teamId, short yearId, string lgId);
}