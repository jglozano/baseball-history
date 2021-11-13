using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class TeamsFranchise
    {
        public TeamsFranchise()
        {
            Teams = new HashSet<Team>();
        }

        [Key]
        public string FranchId { get; set; } = null!;
        public string FranchName { get; set; } = null!;
        public string? Active { get; set; }
        public string? Naassoc { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
