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

        [Required]
        public string Address { get; set; }

        [Required, DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        public DateTime EndDate { get; set; }
        [Display(Name = "Number of desired Volunteers")]
        public int MaxVolunteers { get; set; }

        public ActionType ActionType { get; set; }

        public ICollection<Volunteer> Participants { get; set; }

        public Ngo CreatorNgo { get; set; }


    }
}
