
namespace EHospital.Application.Abstractions.Services;

public interface IPatientService
{
    Task<PatientReadDto> GetPatientByIdAsync(int id);
    Task<PatientReadDto> GetPatientBySerialNumberAsync(string serialNumber);
    Task<List<PatientReadDto>> GetAllPatients();

    Task CreatePatientAsync(PatientDto patientDto);
    Task UpdatePatientAsync(PatientDto patientDto);
    Task DeletePatientAsync(int id);
}
