using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IParkRepository : IDisposable
{
    Task<List<Park>> GetAll();
    Task<Park?> GetById(string parkId);
}