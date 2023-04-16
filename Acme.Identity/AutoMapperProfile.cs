using Acme.Identity.IdentityUser;
using Acme.Identity.Pages.Users;
using AutoMapper;

namespace Acme.Identity
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<CreateUserViewModel, CreateUserDto>().ReverseMap();
        }
    }
}