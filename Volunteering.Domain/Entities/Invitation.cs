using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volunteering.Domain.Enums;

namespace Volunteering.Domain.Entities
{
    public class Invitation
    {
        [Key]
        public int InvitationId { get; set; }

       

        //public string Volunteer { get; set; }

        public int ActionId { get; set; }

        //navigation properties
        [ForeignKey("ActionId")]      //useless in ths case   
        public virtual VoluntaryAction Actions { get; set; }

        public string VolunteerId { get; set; }

        //navigation properties
        [ForeignKey("VolunteerId")]      //useless in ths case   
        public virtual Volunteer Volunteers { get; set; }

        public InvitationStatus Status { get; set; }

       // public virtual ICollection<Volunteer>  VolunteersU { get; set; }
        //public virtual ICollection<VoluntaryAction> ActionsU { get; set; }
    }

}
