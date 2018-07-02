using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteering.Domain.DtoInvitation
{
    public class VoluntaryActionDtoU
    {

        public int ActionId { get; set; }

        public string Name { get; set; }


        public string Address { get; set; }


        public string Description { get; set; }

        public DateTime StartDate { get; set; }


        public DateTime EndDate { get; set; }
        

    }
}
