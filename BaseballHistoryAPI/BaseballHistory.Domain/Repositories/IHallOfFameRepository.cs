using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IHallOfFameRepository : IDisposable
{
    Task<List<HallOfFame>> GetAll();
    Task<HallOfFame?> GetById(string playerId, short yearId, string votedBy);
}