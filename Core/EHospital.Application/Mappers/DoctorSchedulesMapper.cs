namespace EHospital.Application.Mappers;

public class DoctorSchedulesMapper : Profile
{
    public DoctorSchedulesMapper()
    {
        CreateMap<DoctorSchedules, DoctorSchedulesDto>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToDateTime(TimeOnly.MinValue))) 
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToTimeSpan())) 
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToTimeSpan())) 
            .ReverseMap()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Date))) 
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeOnly.FromTimeSpan(src.StartTime))) 
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeOnly.FromTimeSpan(src.EndTime))); 

        CreateMap<DoctorSchedules, DoctorSchedulesCreateDto>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToDateTime(TimeOnly.MinValue)))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToTimeSpan())) 
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToTimeSpan())) 
            .ReverseMap()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Date)))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeOnly.FromTimeSpan(src.StartTime))) 
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeOnly.FromTimeSpan(src.EndTime)));

        CreateMap<DoctorSchedules, DoctorSchedulesUpdateDto>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToDateTime(TimeOnly.MinValue))) 
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToTimeSpan())) 
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToTimeSpan())) 
            .ReverseMap()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.Date))) 
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => TimeOnly.FromTimeSpan(src.StartTime))) 
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => TimeOnly.FromTimeSpan(src.EndTime))); 

        CreateMap<DoctorSchedules, DoctorSchedulesReadDto>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToDateTime(TimeOnly.MinValue))) 
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.ToTimeSpan()))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.ToTimeSpan())) 
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName)); 
    }
}
