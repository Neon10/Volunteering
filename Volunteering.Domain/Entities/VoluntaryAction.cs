using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volunteering.Domain.Enums;
using Volunteering.Domain.ValidationAttribute;

namespace Volunteering.Domain.Entities
{
    public class VoluntaryAction
    {
        public VoluntaryAction()
        {
            Participants= new List<Volunteer>();
        }
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[MinDate(ErrorMessage = "Please enter a date greater than or equal to today")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Number of desired Volunteers")]
        [Range(1, int.MaxValue, ErrorMessage = "Minimum one Volunteers is allowed")]
        public int MaxVolunteers { get; set; }

        public ActionType ActionType { get; set; }

        public ICollection<Volunteer> Participants { get; set; }

        public Ngo CreatorNgo { get; set; }

        [Required]
        public string CreatorNgoId { get; set; }


    }
}
