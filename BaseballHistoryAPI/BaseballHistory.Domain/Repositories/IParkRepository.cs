using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface IParkRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<Park>> GetAll(int pageNumber, int pageSize);
    Task<Park?> GetById(string parkId);
}