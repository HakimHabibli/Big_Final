using AutoMapper;
using EHospital.Application.Dtos.Entites.MedicalHistory;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class MedicalHistoryMapper : Profile
{
    public MedicalHistoryMapper()
    {
        CreateMap<MedicalHistory, MedicalHistoryDto>().ReverseMap();
        CreateMap<MedicalHistory, MedicalHistoryCreateDto>().ReverseMap();
        CreateMap<MedicalHistory, MedicalHistoryDeleteDto>().ReverseMap();
        CreateMap<MedicalHistory, MedicalHistoryReadDto>().ReverseMap();
        CreateMap<MedicalHistory, MedicalHistoryUpdateDto>().ReverseMap();
    }
}
