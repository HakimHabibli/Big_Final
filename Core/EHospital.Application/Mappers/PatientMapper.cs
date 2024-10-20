using AutoMapper;
using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Dtos.Entites.Patient;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class PatientMapper : Profile
{
    public PatientMapper()
    {
        CreateMap<Patient, PatientDto>()
            .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
            .ForMember(dest => dest.EmergencyContact, opt => opt.MapFrom(src => src.EmergencyContact))
            .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.HospitalName))
            .ForMember(dest => dest.InsuranceDetails, opt => opt.MapFrom(src => src.InsuranceDetails));

        CreateMap<PatientDto, Patient>()
            .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
            .ForMember(dest => dest.EmergencyContact, opt => opt.MapFrom(src => src.EmergencyContact))
            .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.HospitalName))  
            .ForMember(dest => dest.InsuranceDetails, opt => opt.MapFrom(src => src.InsuranceDetails));

        CreateMap<Patient, PatientReadDto>()
           .ForMember(dest => dest.MedicalHistories, opt => opt.MapFrom(src => src.MedicalHistories))
           .ForMember(dest => dest.Allergies, opt => opt.MapFrom(src => src.Allergies))
           .ForMember(dest => dest.ContactInfo, opt => opt.MapFrom(src => src.ContactInfo))
           .ForMember(dest => dest.EmergencyContact, opt => opt.MapFrom(src => src.EmergencyContact))
           .ForMember(dest => dest.HospitalName, opt => opt.MapFrom(src => src.HospitalName))
           .ForMember(dest => dest.InsuranceDetails, opt => opt.MapFrom(src => src.InsuranceDetails)).ReverseMap();
    }
}

