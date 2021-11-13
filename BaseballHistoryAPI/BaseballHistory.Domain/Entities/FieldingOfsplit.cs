using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class FieldingOfsplit
    {
        [Key]
        public string PlayerId { get; set; } = null!;
        [Key]
        public string TeamId { get; set; } = null!;
        [Key]
        public string LgId { get; set; } = null!;
        [Key]
        public short YearId { get; set; }
        [Key]
        public short Stint { get; set; }
        [Key]
        public string Pos { get; set; } = null!;
        public short? G { get; set; }
        public short? Gs { get; set; }
        public short? InnOuts { get; set; }
        public short? Po { get; set; }
        public short? A { get; set; }
        public short? E { get; set; }
        public short? Dp { get; set; }
        public short? Pb { get; set; }
        public short? Wp { get; set; }
        public short? Sb { get; set; }
        public short? Cs { get; set; }
        public double? Zr { get; set; }

        public virtual Person Player { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
    }
}
