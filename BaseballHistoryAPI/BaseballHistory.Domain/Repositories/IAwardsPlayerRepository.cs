using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IAwardsPlayerRepository : IDisposable
{
    Task<List<AwardsPlayer>> GetAll();
    Task<AwardsPlayer?> GetById(string playerId, short yearId, string lgId, string awardId);
}