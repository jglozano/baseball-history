using BaseballHistory.Domain.Entities;

namespace BaseballHistory.Domain.Supervisor;

public interface IBaseballHistorySupervisor
{
    Task<List<AllstarFull>> GetAllstarFull();
    Task<AllstarFull?> GetAllstarFullById(string playerId, string teamId, string lgId, short yearId, string gameId);

    Task<List<Appearance>> GetAppearance();
    Task<Appearance?> GetAppearanceById(string playerId, short yearId, string lgId, string teamId);
    
    Task<List<AwardsManager>> GetAwardsManager();
    Task<AwardsManager?> GetAwardsManagerById(string playerId, short yearId, string lgId, string awardId);
    
    Task<List<AwardsPlayer>> GetAwardsPlayer();
    Task<AwardsPlayer?> GetAwardsPlayerById(string playerId, short yearId, string lgId, string awardId);
    
    Task<List<AwardsShareManager>> GetAwardsShareManager();
    Task<AwardsShareManager?> GetAwardsShareManagerById(string playerId, short yearId, string lgId, string awardId);
    
    Task<List<AwardsSharePlayer>> GetAwardsSharePlayer();
    Task<AwardsSharePlayer?> GetAwardsSharePlayerById(string playerId, short yearId, string lgId, string awardId);
    
    Task<List<Batting>> GetBatting();
    Task<Batting?> GetBattingById(string playerId, string teamId, short yearId, string lgId, short stint);
    
    Task<List<BattingPost>> GetBattingPost();
    Task<BattingPost?> GetBattingPostById(string playerId, string teamId, short yearId, string lgId, string round);
    
    Task<List<CollegePlaying>> GetCollegePlaying();
    Task<CollegePlaying?> GetCollegePlayingById(string playerId, short yearId, string schoolId);
    
    Task<List<Fielding>> GetFielding();
    Task<Fielding?> GetFieldingById(string playerId, string teamId, short yearId, string lgId, short stint, string pos);
    
    Task<List<FieldingOf>> GetFieldingOf();
    Task<FieldingOf?> GetFieldingOfById(string playerId, short yearId, short stint);
    
    Task<List<FieldingOfsplit>> GetFieldingOfsplit();
    Task<FieldingOfsplit?> GetFieldingOfsplitById(string playerId, string teamId, short yearId, string lgId, short stint, string pos);
    
    Task<List<FieldingPost>> GetFieldingPost();
    Task<FieldingPost?> GetFieldingPostById(string playerId, string teamId, short yearId, string lgId, string round, string pos);
    
    Task<List<HallOfFame>> GetHallOfFame();
    Task<HallOfFame?> GetHallOfFameById(string playerId, short yearId, string votedBy);
    
    Task<List<HomeGame>> GetHomeGame();
    Task<HomeGame?> GetHomeGameById(string teamId, string lgId, short yearId, string parkId);
    
    Task<List<Manager>> GetManager();
    Task<Manager?> GetManagerById(string playerId, string teamId, short yearId, string lgId, short inseason);
    
    Task<List<ManagersHalf>> GetManagersHalf();
    Task<ManagersHalf?> GetManagersHalfById(string playerId, string teamId, short yearId, string lgId, short inseason, short half);
    
    Task<List<Park>> GetPark();
    Task<Park?> GetParkById(string parkId);
    
    Task<List<Person>> GetPerson();
    Task<Person?> GetPersonById(string playerId);
    
    Task<List<Pitching>> GetPitching();
    Task<Pitching?> GetPitchingById(string playerId, string teamId, short yearId, string lgId, short stint);
    
    Task<List<PitchingPost>> GetPitchingPost();
    Task<PitchingPost?> GetPitchingPostById(string playerId, string teamId, short yearId, string lgId, string round);
    
    Task<List<PlayerBattingTotal>> GetPlayerBattingTotal();
    Task<PlayerBattingTotal?> GetPlayerBattingTotalById(string playerId);
    
    Task<List<PlayerFieldingTotal>> GetPlayerFieldingTotal();
    Task<PlayerFieldingTotal?> GetPlayerFieldingTotalById(string playerId);
    
    Task<List<PlayerPitchingTotal>> GetPlayerPitchingTotal();
    Task<PlayerPitchingTotal?> GetPlayerPitchingTotalById(string playerId);
    
    Task<List<Salary>> GetSalary();
    Task<Salary?> GetSalaryById(string playerId, string teamId, short yearId, string lgId);
    
    Task<List<School>> GetSchool();
    Task<School?> GetSchoolById(string schoolId);
    
    Task<List<SeriesPost>> GetSeriesPost();
    Task<SeriesPost?> GetSeriesPostById(string teamIdwinner, string lgIdwinner, short yearId, string round);
    
    Task<List<Team>> GetTeam();
    Task<Team?> GetTeamById(string teamId, short yearId, string lgId);
    
    Task<List<TeamBattingTotal>> GetTeamBattingTotal();
    Task<TeamBattingTotal?> GetTeamBattingTotalById(string teamId, short yearId, string lgId);
    
    Task<List<TeamFieldingTotal>> GetTeamFieldingTotal();
    Task<TeamFieldingTotal?> GetTeamFieldingTotalById(string teamId, short yearId, string lgId);
    
    Task<List<TeamPitchingTotal>> GetTeamPitchingTotal();
    Task<TeamPitchingTotal?> GetTeamPitchingTotalById(string teamId, short yearId, string lgId);
    
    Task<List<TeamsFranchise>> GetTeamsFranchise();
    Task<TeamsFranchise?> GetTeamsFranchiseById(string franchId);
    
    Task<List<TeamsHalf>> GetTeamsHalf();
    Task<TeamsHalf?> GetTeamsHalfById(string teamId, short yearId, string lgId, string half);
}