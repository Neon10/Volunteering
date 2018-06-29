using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volunteering.Domain.Entities
{
    public class Discussion
    {

        public Discussion()
        {
            Replies = new List<Reply>();
            IsViewed = false;
            CreationDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsViewed { get; set; }

        ///////// REPLIES
        public ICollection<Reply> Replies { get; set; }

        /////////SENDER
        public ApplicationUser Sender { get; set; }
        [Required]
        public string SenderId { get; set; }

        /////////SENT TO
        public ApplicationUser Recipient { get; set; }
        [Required]
        public string RecipientId { get; set; }


    }
}
