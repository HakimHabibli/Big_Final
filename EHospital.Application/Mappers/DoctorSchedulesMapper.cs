using AutoMapper;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class DoctorSchedulesMapper : Profile
{
    public DoctorSchedulesMapper()
    {
        CreateMap<DoctorSchedules, DoctorSchedulesDto>().ReverseMap();
        CreateMap<DoctorSchedules, DoctorSchedulesCreateDto>().ReverseMap();
        CreateMap<DoctorSchedules, DoctorSchedulesUpdateDto>().ReverseMap();
        CreateMap<DoctorSchedules, DoctorSchedulesDeleteDto>().ReverseMap();
        CreateMap<DoctorSchedules, DoctorSchedulesReadDto>().ReverseMap();
    }
}
