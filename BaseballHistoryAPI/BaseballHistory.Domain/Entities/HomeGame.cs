using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class HomeGame
    {
        [Key]
        public string TeamId { get; set; } = null!;
        [Key]
        public string LgId { get; set; } = null!;
        [Key]
        public short YearId { get; set; }
        [Key]
        public string ParkId { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public short? Games { get; set; }
        public short? Openings { get; set; }
        public int? Attendance { get; set; }

        public virtual Park Park { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
    }
}
