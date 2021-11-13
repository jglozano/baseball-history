using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ISeriesPostRepository : IDisposable
{
    Task<List<SeriesPost>> GetAll();
    Task<SeriesPost?> GetById(string teamIdwinner, string lgIdwinner, short yearId, string round);
}