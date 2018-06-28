using System.ComponentModel.DataAnnotations;

namespace Volunteering.Domain.Entities
{
    public class Donation
    {
        [Key]
        public int DonationId { get; set; }
        [Required]
        public int Amount { get; set; }

        public Volunteer Volunteer { get; set; }
        [Required]
        public string VolunteerId { get; set; }
        public FundraisingCampaign Campaign { get; set; }
        [Required]
        public int CampaignId { get; set; }

    }
}
