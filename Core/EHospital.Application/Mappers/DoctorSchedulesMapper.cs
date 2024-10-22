using AutoMapper;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class DoctorSchedulesMapper : Profile
{
    public DoctorSchedulesMapper()
    {
        CreateMap<DoctorSchedules, DoctorSchedulesDto>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date.ToString())))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToTimeSpan()))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToTimeSpan()))
            .ReverseMap();

        CreateMap<DoctorSchedules, DoctorSchedulesCreateDto>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date.ToString())))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToTimeSpan()))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToTimeSpan()))
            .ReverseMap();

        CreateMap<DoctorSchedules, DoctorSchedulesUpdateDto>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date.ToString())))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToTimeSpan()))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToTimeSpan()))
            .ReverseMap();

        CreateMap<DoctorSchedules, DoctorSchedulesDeleteDto>().ReverseMap();

        CreateMap<DoctorSchedules, DoctorSchedulesReadDto>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTime.Parse(src.Date.ToString())))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToTimeSpan()))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToTimeSpan()))
            .ReverseMap();
    }
}
