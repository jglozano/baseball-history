using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class Team
    {
        public Team()
        {
            AllstarFulls = new HashSet<AllstarFull>();
            Appearances = new HashSet<Appearance>();
            BattingPosts = new HashSet<BattingPost>();
            Battings = new HashSet<Batting>();
            FieldingOfsplits = new HashSet<FieldingOfsplit>();
            FieldingPosts = new HashSet<FieldingPost>();
            Fieldings = new HashSet<Fielding>();
            HomeGames = new HashSet<HomeGame>();
            Managers = new HashSet<Manager>();
            ManagersHalves = new HashSet<ManagersHalf>();
            PitchingPosts = new HashSet<PitchingPost>();
            Pitchings = new HashSet<Pitching>();
            Salaries = new HashSet<Salary>();
            SeriesPostTeamNavigations = new HashSet<SeriesPost>();
            SeriesPostTeams = new HashSet<SeriesPost>();
            TeamsHalves = new HashSet<TeamsHalf>();
        }

        [Key]
        public string TeamId { get; set; } = null!;
        [Key]
        public string LgId { get; set; } = null!;
        [Key]
        public short YearId { get; set; }
        public string? FranchId { get; set; }
        public string? DivId { get; set; }
        public short? Rank { get; set; }
        public short? G { get; set; }
        public short? Ghome { get; set; }
        public short? W { get; set; }
        public short? L { get; set; }
        public string? DivWin { get; set; }
        public string? Wcwin { get; set; }
        public string? LgWin { get; set; }
        public string? Wswin { get; set; }
        public short? R { get; set; }
        public short? Ab { get; set; }
        public short? H { get; set; }
        public short? _2b { get; set; }
        public short? _3b { get; set; }
        public short? Hr { get; set; }
        public short? Bb { get; set; }
        public short? So { get; set; }
        public short? Sb { get; set; }
        public short? Cs { get; set; }
        public short? Hbp { get; set; }
        public short? Sf { get; set; }
        public short? Ra { get; set; }
        public short? Er { get; set; }
        public double? Era { get; set; }
        public short? Cg { get; set; }
        public short? Sho { get; set; }
        public short? Sv { get; set; }
        public short? Ipouts { get; set; }
        public short? Ha { get; set; }
        public short? Hra { get; set; }
        public short? Bba { get; set; }
        public short? Soa { get; set; }
        public short? E { get; set; }
        public short? Dp { get; set; }
        public short? Fp { get; set; }
        public string? Name { get; set; }
        public string? Park { get; set; }
        public int? Attendance { get; set; }
        public int? Bpf { get; set; }
        public int? Ppf { get; set; }

        public virtual TeamsFranchise? Franch { get; set; }
        public virtual ICollection<AllstarFull> AllstarFulls { get; set; }
        public virtual ICollection<Appearance> Appearances { get; set; }
        public virtual ICollection<BattingPost> BattingPosts { get; set; }
        public virtual ICollection<Batting> Battings { get; set; }
        public virtual ICollection<FieldingOfsplit> FieldingOfsplits { get; set; }
        public virtual ICollection<FieldingPost> FieldingPosts { get; set; }
        public virtual ICollection<Fielding> Fieldings { get; set; }
        public virtual ICollection<HomeGame> HomeGames { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<ManagersHalf> ManagersHalves { get; set; }
        public virtual ICollection<PitchingPost> PitchingPosts { get; set; }
        public virtual ICollection<Pitching> Pitchings { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<SeriesPost> SeriesPostTeamNavigations { get; set; }
        public virtual ICollection<SeriesPost> SeriesPostTeams { get; set; }
        public virtual ICollection<TeamsHalf> TeamsHalves { get; set; }
    }
}
