using AutoMapper;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class UserDeactivatedScheduleMapper : Profile
{
    public UserDeactivatedScheduleMapper()
    {
        CreateMap<DoctorSchedules, ActiveDoctorScheduleReadDto>()
            .ForMember(dest => dest.ScheduleDate, opt => opt.MapFrom(src => src.Date.ToDateTime(TimeOnly.MinValue)))
            .ForMember(dest => dest.ScheduleId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.Doctor.Id))
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FirstName))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));

        CreateMap<UserDeactivatedSchedule, UserDeactivatedScheduleReadDto>()
            .ForMember(dest => dest.ScheduleId, opt => opt.MapFrom(src => src.DoctorScheduleId))
            .ForMember(dest => dest.DeactivatedByUserId, opt => opt.MapFrom(src => src.UserId)) 
            .ForMember(dest => dest.DeactivatedAt, opt => opt.MapFrom(src => src.DeactivatedAt))
            .ForMember(dest => dest.IsActive, opt => opt.Ignore()) 
            .ForMember(dest => dest.DoctorId, opt => opt.Ignore()) 
            .ForMember(dest => dest.DoctorName, opt => opt.Ignore()) 
            .ForMember(dest => dest.ScheduleDate, opt => opt.Ignore()); 
    }
}

