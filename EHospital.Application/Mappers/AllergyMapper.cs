using AutoMapper;
using EHospital.Application.Dtos.Entites.Allergy;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class AllergyMapper : Profile
{
    public AllergyMapper()
    {
        CreateMap<Allergy, AllergyDto>().ReverseMap();
        CreateMap<Allergy, AllergyCreateDto>().ReverseMap();
        CreateMap<Allergy, AllergyDeleteDto>().ReverseMap();
        CreateMap<Allergy, AllergyReadDto>().ReverseMap();
        CreateMap<Allergy, AllergyUpdateDto>().ReverseMap();
    }
}
