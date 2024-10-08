using AutoMapper;
using EHospital.Application.Dtos.Entites.Patient;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class PatientMapper : Profile
{
    public PatientMapper()
    {
        //TODO:Baxilacaq Action daxilinde nelere ehtiyac olsa  
        CreateMap<Patient, PatientDto>()
            .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
            .ForMember(dest => dest.EmergencyContact, opt => opt.MapFrom(src => src.EmergencyContact))
            .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.Hospital.Name))
            .ForMember(dest => dest.InsuranceDetails, opt => opt.MapFrom(src => src.InsuranceDetails));

        //CreateMap<Patient, PatientCreateDto>().ReverseMap();
        //CreateMap<Patient, PatientDto>().ReverseMap();
        //CreateMap<Patient, PatientDto>().ReverseMap();
        //CreateMap<Patient, PatientDto>().ReverseMap();
    }
}
