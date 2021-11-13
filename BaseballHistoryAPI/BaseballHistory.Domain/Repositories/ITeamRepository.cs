using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ITeamRepository : IDisposable
{
    Task<List<Team>> GetAll();
    Task<Team?> GetById(string teamId, short yearId, string lgId);
}