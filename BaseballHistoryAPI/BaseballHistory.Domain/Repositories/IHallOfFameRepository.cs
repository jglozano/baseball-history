using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IHallOfFameRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<HallOfFame>> GetAll(int pageNumber, int pageSize);
    Task<HallOfFame?> GetById(string playerId, short yearId, string votedBy);
    Task<List<HallOfFame>> GetByPlayerId(string playerId);
}