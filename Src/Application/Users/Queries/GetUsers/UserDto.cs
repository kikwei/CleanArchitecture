using AutoMapper;
using ProductsCleanArch.Application.Common.Mappings;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Application.Users.Queries.GetUsers
{
    public class UserDto : IMapFrom<User>
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Occupation { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>();
        }
    }
}