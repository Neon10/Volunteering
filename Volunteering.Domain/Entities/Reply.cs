using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteering.Domain.Entities
{
    public class Reply
    {
        public Reply()
        {


            Date = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsNew { get; set; }
        public DateTime Date { get; set; }

        // SENDER
        public ApplicationUser Sender { get; set; }
        [Required]
        public string SenderId { get; set; }

        //Owning Discussion
        public Discussion Discussion { get; set; }
        [Required]
        public int DiscussionId { get; set; }



    }
}
