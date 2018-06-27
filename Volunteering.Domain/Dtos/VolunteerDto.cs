using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteering.Domain.Dtos
{
    public class VolunteerDto
    {
        public string VolunteerId { get; set; }       
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }
}
