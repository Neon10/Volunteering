using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volunteering.Domain.Entities;
using Volunteering.Domain.Enums;

namespace Volunteering.Domain.Dtos
{
    public class VoluntaryActionDto
    {
        public VoluntaryActionDto()
        {

            Participants =new List<VolunteerDto>();


        }
        
        public int ActionId { get; set; }

        public string Name { get; set; }

       
        public string Address { get; set; }

       
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

           
        public DateTime EndDate { get; set; }

      
        public int MaxVolunteers { get; set; }

        public ActionType ActionType { get; set; }

        public ICollection<VolunteerDto> Participants { get; set; }


       
        public string CreatorNgoId { get; set; }
    }
}
