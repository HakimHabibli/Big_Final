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

        //Read daxilinde istifade ucun 
        CreateMap<Patient, PatientReadDto>().ReverseMap(); 
        CreateMap<Doctor, DoctorReadDto>().ReverseMap();
    }
}
