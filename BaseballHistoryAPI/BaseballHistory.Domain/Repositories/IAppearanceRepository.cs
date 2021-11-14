using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IAppearanceRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<Appearance>> GetAll(int pageNumber, int pageSize);
    Task<Appearance?> GetById(string playerId, short yearId, string lgId, string teamId);
}