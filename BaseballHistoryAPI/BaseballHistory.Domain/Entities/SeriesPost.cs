using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class SeriesPost
    {
        [Key]
        public string TeamIdwinner { get; set; } = null!;
        [Key]
        public string LgIdwinner { get; set; } = null!;
        [Key]
        public short YearId { get; set; }
        [Key]
        public string Round { get; set; } = null!;
        public string? TeamIdloser { get; set; }
        public string? LgIdloser { get; set; }
        public short? Wins { get; set; }
        public short? Losses { get; set; }
        public short? Ties { get; set; }

        public virtual Team? Team { get; set; }
        public virtual Team TeamNavigation { get; set; } = null!;
    }
}
