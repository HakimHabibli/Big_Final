using EHospital.Domain.Entities;

namespace EHospital.Application.Abstractions.Services;

public interface IDoctorService
{
    //Sirf bu model ucun olan custom methodlari bu inteface daxilində yazırsan 
    Task<Doctor>? GetDoctorByIdAsync(int id);
    Task<List<Patient>> GetAllPatientsAsync(int doctorId);
}
