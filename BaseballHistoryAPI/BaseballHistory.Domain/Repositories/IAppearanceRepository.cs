using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IAppearanceRepository : IDisposable
{
    Task<List<Appearance>> GetAll();
    Task<Appearance?> GetById(string playerId, short yearId, string lgId, string teamId);
}