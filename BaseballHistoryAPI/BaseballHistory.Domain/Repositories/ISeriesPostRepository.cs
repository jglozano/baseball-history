using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ISeriesPostRepository : IDisposable
{
    Task<int> GetTotalCount();
    Task<List<SeriesPost>> GetAll(int pageNumber, int pageSize);
    Task<SeriesPost?> GetById(string teamIdwinner, string lgIdwinner, short yearId, string round);
}