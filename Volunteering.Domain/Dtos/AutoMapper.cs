using AutoMapper;
using Volunteering.Domain.Entities;

namespace Volunteering.Domain.Dtos
{
    public static class AutoMapper
    {


        public static void Configure()
        {
            Mapper.Initialize(m => m.CreateMap<ApplicationUser, UserDto>());

        }

        public static void AutoMapUser(ApplicationUser user, UserDto userDto)
        {
            Mapper.Map(user, userDto);
        }

    }
}
