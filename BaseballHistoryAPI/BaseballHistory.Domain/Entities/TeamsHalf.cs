using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class TeamsHalf
    {
        [Key]
        public string TeamId { get; set; } = null!;
        [Key]
        public string LgId { get; set; } = null!;
        [Key]
        public short YearId { get; set; }
        [Key]
        public string Half { get; set; } = null!;
        public string? DivId { get; set; }
        public string? DivWin { get; set; }
        public short? Rank { get; set; }
        public short? G { get; set; }
        public short? W { get; set; }
        public short? L { get; set; }

        public virtual Team Team { get; set; } = null!;
    }
}
