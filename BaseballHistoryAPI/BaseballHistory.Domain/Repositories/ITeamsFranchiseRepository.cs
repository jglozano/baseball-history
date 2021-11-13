using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Repositories;

public interface ITeamsFranchiseRepository : IDisposable
{
    Task<List<TeamsFranchise>> GetAll();
    Task<TeamsFranchise?> GetById(string franchId);
}