using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteering.Domain.Dtos
{
    public class FundraisingCampaignDto
    {
        public FundraisingCampaignDto()
        {
            Donations = new List<DonationDto>();
        }

        public int CampaignId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TargetAmount { get; set; }
        public UserDto OwnerNgo { get; set; }
        public ICollection<DonationDto> Donations { get; set; }
    }
}
