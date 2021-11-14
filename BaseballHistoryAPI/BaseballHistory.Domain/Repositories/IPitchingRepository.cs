using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IPitchingRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<Pitching>> GetAll(int pageNumber, int pageSize);
    Task<Pitching?> GetById(string playerId, string teamId, short yearId, string lgId, short stint);
}