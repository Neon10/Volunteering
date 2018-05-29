using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Volunteering.Domain.Entities
{
    public class FundraisingCampaign
    {
        [Key]
        public int CampaignId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required, DataType(DataType.Text)]
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int TargetAmount { get; set; }


        public ICollection<Donation> Donations { get; set; }
    }
}
