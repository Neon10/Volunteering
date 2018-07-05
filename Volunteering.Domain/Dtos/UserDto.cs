namespace Volunteering.Domain.Dtos
{
    public class UserDto
    {
        public UserDto()
        {
            Id = "empty";
            Name = "empty";
            Email = "empty";
            PhoneNumber = "empty";
            Role = "empty";
            ImageUrl = "https://www.w3schools.com/w3images/avatar2.png";

        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string ImageUrl { get; set; }


    }
}
