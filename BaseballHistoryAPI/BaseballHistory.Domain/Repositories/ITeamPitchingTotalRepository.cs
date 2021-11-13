using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ITeamPitchingTotalRepository : IDisposable
{
    Task<List<TeamPitchingTotal>> GetAll();
    Task<TeamPitchingTotal?> GetById(string teamId, short yearId, string lgId);
}