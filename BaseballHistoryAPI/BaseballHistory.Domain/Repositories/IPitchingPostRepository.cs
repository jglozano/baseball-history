using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IPitchingPostRepository : IDisposable
{
    Task<List<PitchingPost>> GetAll();
    Task<PitchingPost?> GetById(string playerId, string teamId, short yearId, string lgId, string round);
}