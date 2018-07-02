using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteering.Domain.Dtos
{
    public class DonationDto
    {
        public int DonationId { get; set; }
        public int Amount { get; set; }
        public UserDto Volunteer { get; set; }
        public FundraisingCampaignDto Campaign { get; set; }
    }
}
