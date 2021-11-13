using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IManagerRepository : IDisposable
{
    Task<List<Manager>> GetAll();
    Task<Manager?> GetById(string playerId, string teamId, short yearId, string lgId, short inseason);
}