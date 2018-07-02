using System.Collections.Generic;

namespace Volunteering.Domain.Entities
{
    public class Volunteer : ApplicationUser
    {



        public ICollection<Donation> Donations { get; set; }

        public ICollection<VoluntaryAction> Participations { get; set; }

        public ICollection<Invitation> Invitations { get; set; }
    }
}
