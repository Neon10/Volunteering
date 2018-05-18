using System.ComponentModel.DataAnnotations;

namespace Volunteering.Domain.Entities
{
    public class Action
    {

        [Key]
        public int ActionId { get; set; }

        public string Name { get; set; }
    }
}
