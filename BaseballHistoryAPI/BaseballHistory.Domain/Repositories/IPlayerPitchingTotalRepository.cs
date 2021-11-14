using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IPlayerPitchingTotalRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<PlayerPitchingTotal>> GetAll(int pageNumber, int pageSize);
    Task<PlayerPitchingTotal?> GetById(string playerId);
}