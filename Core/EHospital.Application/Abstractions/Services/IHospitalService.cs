using EHospital.Application.Dtos.Entites.Hospital;

namespace EHospital.Application.Abstractions.Services;

public interface IHospitalService
{
    Task CreateHospitalAsync(HospitalCreateDto hospitalCreateDto);
    Task UpdateHospitalAsync(HospitalUpdateDto hospitalUpdateDto);
    Task DeleteHospitalAsync(HospitalDeleteDto hospitalDeleteDto);
    Task<HospitalDto> GetHospitalDetailsAsync(int id);
    Task<IEnumerable<HospitalReadDto>> GetAllHospitalsAsync();
    Task<HospitalReadDto> GetHospitalByIdAsync(int id);
}