using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IBattingRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<Batting>> GetAll(int pageNumber, int pageSize);
    Task<Batting?> GetById(string playerId, string teamId, short yearId, string lgId, short stint);
}