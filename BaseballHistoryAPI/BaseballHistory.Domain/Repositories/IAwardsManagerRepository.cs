using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IAwardsManagerRepository : IDisposable
{
    Task<List<AwardsManager>> GetAll();
    Task<AwardsManager?> GetById(string playerId, short yearId, string lgId, string awardId);
}