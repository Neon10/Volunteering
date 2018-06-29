using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteering.Domain.Dtos;
using Volunteering.Domain.Enums;

namespace Volunteering.Domain.DtoInvitation
{
    public class InvitationDto
    {
        public InvitationDto()
        {

            Volunteers = new List<VolunteerDto>();
            Actions = new List<VoluntaryActionDto>();

        }

        public int InvitationId { get; set; }



        //public string Volunteer { get; set; }

        public int ActionId { get; set; }

        //navigation properties



        public string VolunteerId { get; set; }

        //navigation properties



        public InvitationStatus Status { get; set; }


        public ICollection<VolunteerDto> Volunteers { get; set; }
        public ICollection<VoluntaryActionDto> Actions { get; set; }


    }
}