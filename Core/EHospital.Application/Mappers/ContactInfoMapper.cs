
namespace EHospital.Application.Mappers;

public class ContactInfoMapper : Profile
{
    public ContactInfoMapper()
    {
        CreateMap<ContactInfo, ContactInfoDto>().ReverseMap();
        CreateMap<ContactInfo, ContactInfoCreateDto>().ReverseMap();
        CreateMap<ContactInfo, ContactInfoDeleteDto>().ReverseMap();
        CreateMap<ContactInfo, ContactInfoReadDto>().ReverseMap();
        CreateMap<ContactInfo, ContactInfoUpdateDto>().ReverseMap();
    }
}
