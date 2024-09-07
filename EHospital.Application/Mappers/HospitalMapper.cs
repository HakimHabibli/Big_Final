using AutoMapper;
using EHospital.Application.Dtos.Entites.Hospital;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class HospitalMapper : Profile
{
    public HospitalMapper()
    {
        CreateMap<Hospital, HospitalDto>().ReverseMap();
        CreateMap<Hospital, HospitalCreateDto>().ReverseMap();
        CreateMap<Hospital, HospitalReadDto>().ReverseMap();
        CreateMap<Hospital, HospitalUpdateDto>().ReverseMap();
        CreateMap<Hospital, HospitalDeleteDto>().ReverseMap();
    }
}
