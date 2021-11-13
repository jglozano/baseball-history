using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ITeamFieldingTotalRepository : IDisposable
{
    Task<List<TeamFieldingTotal>> GetAll();
    Task<TeamFieldingTotal?> GetById(string teamId, short yearId, string lgId);
}