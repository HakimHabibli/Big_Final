
namespace EHospital.Application.Abstractions.Services;

public interface IMedicalHistoryService
{
    Task<IEnumerable<MedicalHistoryReadDto>> GetMedicalHistoriesBySerialNumberAsync(string serialNumber);
    Task<IEnumerable<MedicalHistoryReadDto>> GetAllMedicalHistoriesAsync();

    Task CreateMedicalHistoryAsync(MedicalHistoryCreateDto medicalHistoryCreateDto);
    Task UpdateMedicalHistoryAsync(MedicalHistoryUpdateDto medicalHistoryUpdateDto);
    Task DeleteMedicalHistoryAsync(MedicalHistoryDeleteDto medicalHistoryDeleteDto);
}
