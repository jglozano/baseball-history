using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IHomeGameRepository : IDisposable
{
    Task<List<HomeGame>> GetAll();
    Task<HomeGame?> GetById(string teamId, string lgId, short yearId, string parkId);
}