using AutoMapper;
using Exercise.Domain.CRUD.Manufacturer;
using Exercise.Domain.CRUD.Phone;
using Exercise.Domain.CRUD.User;
using Exercise.Domain.Identity;
using Exercise.Domain.Records;

namespace Exercise.Infrastructure.MappingProfiles
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            CreateMap<ReadPhone, Phone>().ReverseMap();
            CreateMap<CreatePhone, Phone>().ReverseMap();
            CreateMap<UpdatePhone, Phone>().ReverseMap();
            
            CreateMap<ReadManufacturer, Manufacturer>().ReverseMap();
            CreateMap<CreateManufacturer, Manufacturer>().ReverseMap();
            CreateMap<UpdateManufacturer, Manufacturer>().ReverseMap();
            
            CreateMap<ReadUser,AppUser>().ReverseMap();
            CreateMap<CreateUser, AppUser>().ReverseMap();
        }
    }
}