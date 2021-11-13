using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IBattingRepository : IDisposable
{
    Task<List<Batting>> GetAll();
    Task<Batting?> GetById(string playerId, string teamId, short yearId, string lgId, short stint);
}