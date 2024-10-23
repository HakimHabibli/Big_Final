namespace EHospital.Application.Mappers;

public class AppointmentMapper : Profile
{
    public AppointmentMapper()
    {
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<Appointment, AppointmentCreateDto>().ReverseMap();
        CreateMap<Appointment, AppointmentReadDto>()
        .ForMember(d => d.DoctorName, opt => opt.MapFrom(src => src.Doctor.FirstName))
        .ForMember(d => d.PatientName, opt => opt.MapFrom(src => src.Patient.FirstName))
        .ForMember(d => d.DoctorName, opt => opt.NullSubstitute("Doctor name not available"))
        .ForMember(d => d.PatientName, opt => opt.NullSubstitute("Patient name not available"))
        .ReverseMap();
        //Appointment modeli daxilindeki propertini dto daxilindeki propa mapliyirik
        CreateMap<Appointment, AppointmentUpdateDto>().ReverseMap();
        CreateMap<Appointment, AppointmentDeleteDto>().ReverseMap();
    }
}
