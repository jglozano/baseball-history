using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class TeamFieldingTotal
    {
        [Key]
        public string TeamId { get; set; } = null!;
        [Key]
        public short YearId { get; set; }
        [Key]
        public string LgId { get; set; } = null!;
        public int? G { get; set; }
        public int? Gs { get; set; }
        public int? InnOuts { get; set; }
        public int? Po { get; set; }
        public int? A { get; set; }
        public int? E { get; set; }
        public int? Dp { get; set; }
        public int? Pb { get; set; }
        public int? Wp { get; set; }
        public int? Sb { get; set; }
        public int? Cs { get; set; }
        public double? Zr { get; set; }
    }
}
