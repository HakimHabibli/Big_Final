using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Dtos.Entites.Patient;

namespace EHospital.Application.Abstractions.Services;

public interface IDoctorService
{
    //Sirf bu model ucun olan custom methodlarin başlıqlarini yəni kontraklarini bu inteface daxilində yazırsan 
    Task<DoctorDto>? GetDoctorByIdAsync(int id);
    Task<List<PatientDto>> GetAllPatientsAsync(int doctorId);
}
