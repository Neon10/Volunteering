using System.ComponentModel.DataAnnotations;

namespace Volunteering.Domain.Entities
{
    public class Preference
    {
        public Preference()
        {
            Weekends = true;
            AllWeak = false;
            Type = "Any";
            MaxDistance = 10;

        }

        [Key]
        public int Id { get; set; }

        public bool Weekends { get; set; }

        public bool AllWeak { get; set; }

        public string Type { get; set; }

        public int MaxDistance { get; set; }

        public string VolunteerId { get; set; }

    }
}
