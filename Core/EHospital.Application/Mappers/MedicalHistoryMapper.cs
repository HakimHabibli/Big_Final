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
        CreateMap<MedicalHistory, MedicalHistoryReadDto>()
        .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FirstName))
        .ForMember(dest => dest.PatientSurname, opt => opt.MapFrom(src => src.Patient.LastName))
        .ForMember(dest => dest.PatientSerialNumber, opt => opt.MapFrom(src => src.Patient.SerialNumber))
        .ForMember(dest => dest.PatientGender, opt => opt.MapFrom(src => src.Patient.Gender.ToString()));
        CreateMap<MedicalHistory, MedicalHistoryUpdateDto>().ReverseMap();
    }
}
