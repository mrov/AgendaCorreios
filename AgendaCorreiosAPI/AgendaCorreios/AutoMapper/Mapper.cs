using AutoMapper;
using Models;
using Models.DTOs.Output;

namespace AgendaCorreios.AutoMapper
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserAddressDTO>(); // Mapping from User to UserAddressDTO
            CreateMap<UserAddressDTO, User>(); // Mapping from UserAddressDTO to User

            CreateMap<AddressDTO, Address>();
            CreateMap<Address, AddressDTO>();

        }
    }
}
