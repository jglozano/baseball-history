using BaseballHistory.Domain.Entities;
using BaseballHistory.Domain.Repositories;

namespace BaseballHistory.Domain.Supervisor;

public class BaseballHistorySupervisor : IBaseballHistorySupervisor
{
    private readonly IAllstarFullRepository _allstarFullRepository;
    private readonly IAppearanceRepository _appearanceRepository;
    private readonly IAwardsManagerRepository _awardsManagerRepository;
    private readonly IAwardsPlayerRepository _awardsPlayerRepository;
    private readonly IAwardsShareManagerRepository _awardsShareManagerRepository;
    private readonly IAwardsSharePlayerRepository _awardsSharePlayerRepository;
    private readonly IBattingRepository _battingRepository;
    private readonly IBattingPostRepository _battingPostRepository;
    private readonly ICollegePlayingRepository _collegePlayingRepository;
    private readonly IFieldingRepository _fieldingRepository;
    private readonly IFieldingOfRepository _fieldingOfRepository;
    private readonly IFieldingOfsplitRepository _fieldingOfsplitRepository;
    private readonly IFieldingPostRepository _fieldingPostRepository;
    private readonly IHallOfFameRepository _hallOfFameRepository;
    private readonly IHomeGameRepository _homeGameRepository;
    private readonly IManagerRepository _managerRepository;
    private readonly IManagersHalfRepository _managersHalfRepository;
    private readonly IParkRepository _parkRepository;
    private readonly IPersonRepository _personRepository;
    private readonly IPitchingRepository _pitchingRepository;
    private readonly IPitchingPostRepository _pitchingPostRepository;
    private readonly IPlayerBattingTotalRepository _playerBattingTotalRepository;
    private readonly IPlayerFieldingTotalRepository _playerFieldingTotalRepository;
    private readonly IPlayerPitchingTotalRepository _playerPitchingTotalRepository;
    private readonly ISalaryRepository _salaryRepository;
    private readonly ISchoolRepository _schoolRepository;
    private readonly ISeriesPostRepository _seriesPostRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly ITeamBattingTotalRepository _teamBattingTotalRepository;
    private readonly ITeamFieldingTotalRepository _teamFieldingTotalRepository;
    private readonly ITeamPitchingTotalRepository _teamPitchingTotalRepository;
    private readonly ITeamsFranchiseRepository _teamsFranchiseRepository;
    private readonly ITeamsHalfRepository _teamsHalfRepository;

    public BaseballHistorySupervisor(
        IAllstarFullRepository allstarFullRepository, IAppearanceRepository appearanceRepository,
        IAwardsManagerRepository awardsManagerRepository, IAwardsPlayerRepository awardsPlayerRepository,
        IAwardsSharePlayerRepository awardsSharePlayerRepository,
        IAwardsShareManagerRepository awardsShareManagerRepository, IBattingRepository battingRepository,
        IBattingPostRepository battingPostRepository, ICollegePlayingRepository collegePlayingRepository,
        IFieldingRepository fieldingRepository, IFieldingOfRepository fieldingOfRepository,
        IFieldingOfsplitRepository fieldingOfsplitRepository, IFieldingPostRepository fieldingPostRepository,
        IHallOfFameRepository hallOfFameRepository, IHomeGameRepository homeGameRepository,
        IManagerRepository managerRepository, IManagersHalfRepository managersHalfRepository,
        IParkRepository parkRepository, IPersonRepository personRepository, IPitchingRepository pitchingRepository,
        IPitchingPostRepository pitchingPostRepository, IPlayerBattingTotalRepository playerBattingTotalRepository,
        IPlayerFieldingTotalRepository playerFieldingTotalRepository,
        IPlayerPitchingTotalRepository playerPitchingTotalRepository, ISalaryRepository salaryRepository,
        ISchoolRepository schoolRepository, ISeriesPostRepository seriesPostRepository, ITeamRepository teamRepository,
        ITeamBattingTotalRepository teamBattingTotalRepository,
        ITeamFieldingTotalRepository teamFieldingTotalRepository,
        ITeamPitchingTotalRepository teamPitchingTotalRepository, ITeamsFranchiseRepository teamsFranchiseRepository,
        ITeamsHalfRepository teamsHalfRepository)
    {
        _allstarFullRepository = allstarFullRepository;
        _appearanceRepository = appearanceRepository;
        _awardsManagerRepository = awardsManagerRepository;
        _awardsPlayerRepository = awardsPlayerRepository;
        _awardsSharePlayerRepository = awardsSharePlayerRepository;
        _awardsShareManagerRepository = awardsShareManagerRepository;
        _battingRepository = battingRepository;
        _battingPostRepository = battingPostRepository;
        _collegePlayingRepository = collegePlayingRepository;
        _fieldingRepository = fieldingRepository;
        _fieldingOfRepository = fieldingOfRepository;
        _fieldingOfsplitRepository = fieldingOfsplitRepository;
        _fieldingPostRepository = fieldingPostRepository;
        _hallOfFameRepository = hallOfFameRepository;
        _homeGameRepository = homeGameRepository;
        _managerRepository = managerRepository;
        _managersHalfRepository = managersHalfRepository;
        _parkRepository = parkRepository;
        _personRepository = personRepository;
        _pitchingRepository = pitchingRepository;
        _pitchingPostRepository = pitchingPostRepository;
        _playerBattingTotalRepository = playerBattingTotalRepository;
        _playerFieldingTotalRepository = playerFieldingTotalRepository;
        _playerPitchingTotalRepository = playerPitchingTotalRepository;
        _salaryRepository = salaryRepository;
        _schoolRepository = schoolRepository;
        _seriesPostRepository = seriesPostRepository;
        _teamRepository = teamRepository;
        _teamBattingTotalRepository = teamBattingTotalRepository;
        _teamFieldingTotalRepository = teamFieldingTotalRepository;
        _teamPitchingTotalRepository = teamPitchingTotalRepository;
        _teamsFranchiseRepository = teamsFranchiseRepository;
        _teamsHalfRepository = teamsHalfRepository;
    }

    public async Task<List<AllstarFull>> GetAllstarFull() => await _allstarFullRepository.GetAll();

    public async Task<AllstarFull?> GetAllstarFullById(string playerId, string teamId, string lgId, short yearId,
        string gameId)
    {
        return await _allstarFullRepository.GetById(playerId, teamId, lgId, yearId, gameId);
    }

    public async Task<List<Appearance>> GetAppearance() => await _appearanceRepository.GetAll();

    public async Task<Appearance?> GetAppearanceById(string playerId, short yearId, string lgId, string teamId)
    {
        return await _appearanceRepository.GetById(playerId, yearId, lgId, teamId);
    }

    public async Task<List<AwardsManager>> GetAwardsManager() => await _awardsManagerRepository.GetAll();

    public async Task<AwardsManager?> GetAwardsManagerById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _awardsManagerRepository.GetById(playerId, yearId, lgId, awardId);
    }

    public async Task<List<AwardsPlayer>> GetAwardsPlayer() => await _awardsPlayerRepository.GetAll();

    public async Task<AwardsPlayer?> GetAwardsPlayerById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _awardsPlayerRepository.GetById(playerId, yearId, lgId, awardId);
    }

    public async Task<List<AwardsShareManager>> GetAwardsShareManager() => await _awardsShareManagerRepository.GetAll();

    public async Task<AwardsShareManager?> GetAwardsShareManagerById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _awardsShareManagerRepository.GetById(playerId, yearId, lgId, awardId);
    }

    public async Task<List<AwardsSharePlayer>> GetAwardsSharePlayer() => await _awardsSharePlayerRepository.GetAll();

    public async Task<AwardsSharePlayer?> GetAwardsSharePlayerById(string playerId, short yearId, string lgId, string awardId)
    {
        return await _awardsSharePlayerRepository.GetById(playerId, yearId, lgId, awardId);
    }

    public async Task<List<Batting>> GetBatting() => await _battingRepository.GetAll();

    public async Task<Batting?> GetBattingById(string playerId, string teamId, short yearId, string lgId, short stint)
    {
        return await _battingRepository.GetById(playerId, teamId, yearId, lgId, stint);
    }

    public async Task<List<BattingPost>> GetBattingPost() => await _battingPostRepository.GetAll();

    public async Task<BattingPost?> GetBattingPostById(string playerId, string teamId, short yearId, string lgId, string round)
    {
        return await _battingPostRepository.GetById(playerId, teamId, yearId, lgId, round);
    }

    public async Task<List<CollegePlaying>> GetCollegePlaying() => await _collegePlayingRepository.GetAll();

    public async Task<CollegePlaying?> GetCollegePlayingById(string playerId, short yearId, string schoolId)
    {
        return await _collegePlayingRepository.GetById(playerId, yearId, schoolId);
    }

    public async Task<List<Fielding>> GetFielding() => await _fieldingRepository.GetAll();

    public async Task<Fielding?> GetFieldingById(string playerId, string teamId, short yearId, string lgId, short stint, string pos)
    {
        return await _fieldingRepository.GetById(playerId, teamId, yearId, lgId, stint, pos);
    }

    public async Task<List<FieldingOf>> GetFieldingOf() => await _fieldingOfRepository.GetAll();

    public async Task<FieldingOf?> GetFieldingOfById(string playerId, short yearId, short stint)
    {
        return await _fieldingOfRepository.GetById(playerId, yearId, stint);
    }

    public async Task<List<FieldingOfsplit>> GetFieldingOfsplit() => await _fieldingOfsplitRepository.GetAll();

    public async Task<FieldingOfsplit?> GetFieldingOfsplitById(string playerId, string teamId, short yearId, string lgId, short stint, string pos)
    {
        return await _fieldingOfsplitRepository.GetById(playerId, teamId, yearId, lgId, stint, pos);
    }

    public async Task<List<FieldingPost>> GetFieldingPost() => await _fieldingPostRepository.GetAll();

    public async Task<FieldingPost?> GetFieldingPostById(string playerId, string teamId, short yearId, string lgId, string round, string pos)
    {
        return await _fieldingPostRepository.GetById(playerId, teamId, yearId, lgId, round, pos);
    }

    public async Task<List<HallOfFame>> GetHallOfFame() => await _hallOfFameRepository.GetAll();

    public async Task<HallOfFame?> GetHallOfFameById(string playerId, short yearId, string votedBy)
    {
        return await _hallOfFameRepository.GetById(playerId, yearId, votedBy);
    }

    public async Task<List<HomeGame>> GetHomeGame() => await _homeGameRepository.GetAll();

    public async Task<HomeGame?> GetHomeGameById(string teamId, string lgId, short yearId, string parkId)
    {
        return await _homeGameRepository.GetById(teamId, lgId, yearId, parkId);
    }

    public async Task<List<Manager>> GetManager() => await _managerRepository.GetAll();

    public async Task<Manager?> GetManagerById(string playerId, string teamId, short yearId, string lgId, short inseason)
    {
        return await _managerRepository.GetById(playerId, teamId, yearId, lgId, inseason);
    }

    public async Task<List<ManagersHalf>> GetManagersHalf() => await _managersHalfRepository.GetAll();

    public async Task<ManagersHalf?> GetManagersHalfById(string playerId, string teamId, short yearId, string lgId, short inseason, short half)
    {
        return await _managersHalfRepository.GetById(playerId, teamId, yearId, lgId, inseason, half);
    }

    public async Task<List<Park>> GetPark() => await _parkRepository.GetAll();

    public async Task<Park?> GetParkById(string parkId)
    {
        return await _parkRepository.GetById(parkId);
    }

    public async Task<List<Person>> GetPerson() => await _personRepository.GetAll();

    public async Task<Person?> GetPersonById(string playerId)
    {
        return await _personRepository.GetById(playerId);
    }

    public async Task<List<Pitching>> GetPitching() => await _pitchingRepository.GetAll();

    public async Task<Pitching?> GetPitchingById(string playerId, string teamId, short yearId, string lgId, short stint)
    {
        return await _pitchingRepository.GetById(playerId, teamId, yearId, lgId, stint);
    }

    public async Task<List<PitchingPost>> GetPitchingPost() => await _pitchingPostRepository.GetAll();

    public async Task<PitchingPost?> GetPitchingPostById(string playerId, string teamId, short yearId, string lgId, string round)
    {
        return await _pitchingPostRepository.GetById(playerId, teamId, yearId, lgId, round);
    }

    public async Task<List<PlayerBattingTotal>> GetPlayerBattingTotal() => await _playerBattingTotalRepository.GetAll();

    public async Task<PlayerBattingTotal?> GetPlayerBattingTotalById(string playerId)
    {
        return await _playerBattingTotalRepository.GetById(playerId);
    }

    public async Task<List<PlayerFieldingTotal>> GetPlayerFieldingTotal() => await _playerFieldingTotalRepository.GetAll();

    public async Task<PlayerFieldingTotal?> GetPlayerFieldingTotalById(string playerId)
    {
        return await _playerFieldingTotalRepository.GetById(playerId);
    }

    public async Task<List<PlayerPitchingTotal>> GetPlayerPitchingTotal() => await _playerPitchingTotalRepository.GetAll();

    public async Task<PlayerPitchingTotal?> GetPlayerPitchingTotalById(string playerId)
    {
        return await _playerPitchingTotalRepository.GetById(playerId);
    }

    public async Task<List<Salary>> GetSalary() => await _salaryRepository.GetAll();

    public async Task<Salary?> GetSalaryById(string playerId, string teamId, short yearId, string lgId)
    {
        return await _salaryRepository.GetById(playerId, teamId, yearId, lgId);
    }

    public async Task<List<School>> GetSchool() => await _schoolRepository.GetAll();

    public async Task<School?> GetSchoolById(string schoolId)
    {
        return await _schoolRepository.GetById(schoolId);
    }

    public async Task<List<SeriesPost>> GetSeriesPost() => await _seriesPostRepository.GetAll();

    public async Task<SeriesPost?> GetSeriesPostById(string teamIdwinner, string lgIdwinner, short yearId, string round)
    {
        return await _seriesPostRepository.GetById(teamIdwinner, lgIdwinner, yearId, round);
    }

    public async Task<List<Team>> GetTeam() => await _teamRepository.GetAll();

    public async Task<Team?> GetTeamById(string teamId, short yearId, string lgId)
    {
        return await _teamRepository.GetById(teamId, yearId, lgId);
    }

    public async Task<List<TeamBattingTotal>> GetTeamBattingTotal() => await _teamBattingTotalRepository.GetAll();

    public async Task<TeamBattingTotal?> GetTeamBattingTotalById(string teamId, short yearId, string lgId)
    {
        return await _teamBattingTotalRepository.GetById(teamId, yearId, lgId);
    }

    public async Task<List<TeamFieldingTotal>> GetTeamFieldingTotal() => await _teamFieldingTotalRepository.GetAll();

    public async Task<TeamFieldingTotal?> GetTeamFieldingTotalById(string teamId, short yearId, string lgId)
    {
        return await _teamFieldingTotalRepository.GetById(teamId, yearId, lgId);
    }

    public async Task<List<TeamPitchingTotal>> GetTeamPitchingTotal() => await _teamPitchingTotalRepository.GetAll();

    public async Task<TeamPitchingTotal?> GetTeamPitchingTotalById(string teamId, short yearId, string lgId)
    {
        return await _teamPitchingTotalRepository.GetById(teamId, yearId, lgId);
    }

    public async Task<List<TeamsFranchise>> GetTeamsFranchise() => await _teamsFranchiseRepository.GetAll();

    public async Task<TeamsFranchise?> GetTeamsFranchiseById(string franchId)
    {
        return await _teamsFranchiseRepository.GetById(franchId);
    }

    public async Task<List<TeamsHalf>> GetTeamsHalf() => await _teamsHalfRepository.GetAll();

    public async Task<TeamsHalf?> GetTeamsHalfById(string teamId, short yearId, string lgId, string half)
    {
        return await _teamsHalfRepository.GetById(teamId, yearId, lgId, half);
    }
}