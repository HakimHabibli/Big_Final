using EHospital.Application.Dtos.Entites.MedicalHistory;

namespace EHospital.Application.Abstractions.Services;

public interface IMedicalHistoryService
{
    Task<MedicalHistoryReadDto> GetMedicalHistoryBySerialNumberAsync(string serialNumber);
    Task<IEnumerable<MedicalHistoryReadDto>> GetAllMedicalHistoriesAsync();

    Task CreateMedicalHistoryAsync(MedicalHistoryCreateDto medicalHistoryCreateDto);
    Task UpdateMedicalHistoryAsync(MedicalHistoryUpdateDto medicalHistoryUpdateDto);
    Task DeleteMedicalHistoryAsync(MedicalHistoryDeleteDto medicalHistoryDeleteDto);
}
