using dinks_server.Entities;
using AutoMapper;
using dinks_server.DTOs;

namespace dinks_server.AutoMapperProfiles
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
