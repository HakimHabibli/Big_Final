
namespace EHospital.Application.Abstractions.Services;

public interface IPatientDoctorService 
{
    Task AddPatientDoctorAsync(PatientDoctorDto patientDoctorDto);
    Task RemovePatientDoctorAsync(PatientDoctorDto patientDoctorDto);
    Task<IEnumerable<PatientDoctor>> GetAllPatientsByDoctorIdAsync(int doctorId);

}