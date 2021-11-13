using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IPitchingRepository : IDisposable
{
    Task<List<Pitching>> GetAll();
    Task<Pitching?> GetById(string playerId, string teamId, short yearId, string lgId, short stint);
}