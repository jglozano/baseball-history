using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IManagersHalfRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<ManagersHalf>> GetAll(int pageNumber, int pageSize);
    Task<ManagersHalf?> GetById(string playerId, string teamId, short yearId, string lgId, short inseason, short half);
}