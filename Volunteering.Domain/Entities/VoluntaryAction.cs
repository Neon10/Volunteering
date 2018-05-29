using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volunteering.Domain.Enums;

namespace Volunteering.Domain.Entities
{
    public class VoluntaryAction
    {
        [Key]
        public int ActionId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public int MaxVolunteers { get; set; }

        public ActionType ActionType { get; set; }

        public ICollection<Volunteer> Participants { get; set; }

        public Ngo CreatorNgo { get; set; }


    }
}
