using System.ComponentModel.DataAnnotations;

namespace BaseballHistory.Domain.Entities
{
    public class Park
    {
        public Park()
        {
            HomeGames = new HashSet<HomeGame>();
        }

        [Key]
        public string ParkId { get; set; } = null!;
        public string? Name { get; set; }
        public string? Alias { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<HomeGame> HomeGames { get; set; }
    }
}
