using System.ComponentModel.DataAnnotations;

namespace Volunteering.Domain.Entities
{
    public class Gift
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        [Required]
        public string DonatorId { get; set; }

    }
}
