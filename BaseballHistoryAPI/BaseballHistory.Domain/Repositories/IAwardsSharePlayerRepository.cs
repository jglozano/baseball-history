using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IAwardsSharePlayerRepository : IDisposable
{
    Task<List<AwardsSharePlayer>> GetAll();
    Task<AwardsSharePlayer?> GetById(string playerId, short yearId, string lgId, string awardId);
}