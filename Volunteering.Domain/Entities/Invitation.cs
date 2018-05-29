using System.ComponentModel.DataAnnotations;
using Volunteering.Domain.Enums;

namespace Volunteering.Domain.Entities
{
    public class Invitation
    {
        [Key]
        public int InvitationId { get; set; }

        public VoluntaryAction Action { get; set; }

        public Volunteer Volunteer { get; set; }

        public InvitationStatus Status { get; set; }

    }
}
