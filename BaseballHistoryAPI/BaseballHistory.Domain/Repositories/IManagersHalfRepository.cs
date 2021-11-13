using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IManagersHalfRepository : IDisposable
{
    Task<List<ManagersHalf>> GetAll();
    Task<ManagersHalf?> GetById(string playerId, string teamId, short yearId, string lgId, short inseason, short half);
}