using AutoMapper;
using EHospital.Application.Dtos.Entites.EmergencyContact;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class EmergencyContactMapper : Profile
{
    public EmergencyContactMapper()
    {
        CreateMap<EmergencyContact, EmergencyContactDto>().ReverseMap();
        CreateMap<EmergencyContact, EmergencyContactReadDto>().ReverseMap();
        CreateMap<EmergencyContact, EmergencyContactDeleteDto>().ReverseMap();
        CreateMap<EmergencyContact, EmergencyContactCreateDto>().ReverseMap();
        CreateMap<EmergencyContact, EmergencyContactUpdateDto>().ReverseMap();
    }
}
