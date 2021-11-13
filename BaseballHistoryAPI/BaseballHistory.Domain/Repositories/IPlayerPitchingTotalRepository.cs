using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IPlayerPitchingTotalRepository : IDisposable
{
    Task<List<PlayerPitchingTotal>> GetAll();
    Task<PlayerPitchingTotal?> GetById(string playerId);
}