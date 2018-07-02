using System.Collections.Generic;

namespace Volunteering.Domain.Entities
{
    public class Ngo : ApplicationUser
    {

        public ICollection<VoluntaryAction> VoluntaryActions { get; set; }
    }
}
