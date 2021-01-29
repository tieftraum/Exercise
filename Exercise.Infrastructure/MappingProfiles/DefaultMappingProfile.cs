using AutoMapper;
using Exercise.Domain.CRUD.Phone;
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
        }
    }
}