using System.ComponentModel.DataAnnotations;

namespace StarWarsSite.Models
{
    public class Card
    {
        public Card() => DateAdded = DateTime.UtcNow;

        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public int BirthDate { get; set; }
        public string BirthPlanet { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public int Height { get; set; }
        public string HairColor { get; set; }
        public string EyesColor { get; set; }
        public string Description { get; set; }
        public string Movies { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
