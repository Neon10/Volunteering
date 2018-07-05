using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Volunteering.Domain.Entities
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public ICollection<ApplicationUser> Voters { get; set; }

        [Required]
        public int CampaignId { get; set; }
    }
}
