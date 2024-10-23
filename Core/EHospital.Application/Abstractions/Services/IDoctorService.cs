namespace EHospital.Application.Abstractions.Services;

public interface IDoctorService
{
    //Sirf bu model ucun olan custom methodlarin başlıqlarini yəni kontraklarini bu inteface daxilində yazırsan 
    Task<DoctorReadDto>? GetDoctorByIdAsync(int id);
    Task<IEnumerable<DoctorReadDto>> GetAllDoctorsAsync();
    Task<List<PatientDto>> GetAllPatientsAsync(int doctorId);//Doctorun hansi patientl'ri oldugunu gostermek istediyim method


    Task CreateDoctorAsync(DoctorCreateDto doctorCreateDTO);
    Task UpdateDoctorAsync(DoctorUpdateDto doctorUpdateDto);
    Task DeleteDoctorAsync(DoctorDeleteDto doctorDeleteDto);
}
