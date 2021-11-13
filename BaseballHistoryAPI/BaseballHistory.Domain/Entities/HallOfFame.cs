using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class HallOfFame
    {
        [Key]
        public string PlayerId { get; set; } = null!;
        [Key]
        public short YearId { get; set; }
        [Key]
        public string VotedBy { get; set; } = null!;
        public short? Ballots { get; set; }
        public short? Needed { get; set; }
        public short? Votes { get; set; }
        public string? Inducted { get; set; }
        public string? Category { get; set; }
        public string? NeededNote { get; set; }

        public virtual Person Player { get; set; } = null!;
    }
}
