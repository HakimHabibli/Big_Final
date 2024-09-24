using AutoMapper;
using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Dtos.Entites.Hospital;
using EHospital.Application.Dtos.Entites.Patient;
using EHospital.Domain.Entities;

namespace EHospital.Application.Concretes.Services;

public class HospitalService : IHospitalService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public HospitalService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateHospitalAsync(HospitalCreateDto hospitalCreateDto)
    {
        var hospital = _mapper.Map<Hospital>(hospitalCreateDto);
        await _unitOfWork.HospitalWriteRepository.CreateAsync(hospital);

    }

    public async Task DeleteHospitalAsync(HospitalDeleteDto hospitalDeleteDto)
    {
        var hospital = await _unitOfWork.HospitalReadRepository.GetByIdAsync(hospitalDeleteDto.Id);
        if (hospital == null) { throw new KeyNotFoundException("Hospital not Found"); }
        await _unitOfWork.HospitalWriteRepository.DeleteAsync(hospital);
    }

    public async Task<IEnumerable<HospitalReadDto>> GetAllHospitalsAsync()
    {
        var hospitals = await _unitOfWork.HospitalReadRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<HospitalReadDto>>(hospitals);
    }

    public async Task<HospitalReadDto> GetHospitalByIdAsync(int id)
    {
        var hospital = await _unitOfWork.HospitalReadRepository.GetByIdAsync(id);
        return _mapper.Map<HospitalReadDto>(hospital);
    }

    public async Task<HospitalDto> GetHospitalDetailsAsync(int id)
    {
        var hospital = await _unitOfWork.HospitalReadRepository.GetByIdAsync(id);
        if (hospital == null)
        {
            throw new KeyNotFoundException("Hospital not found.");
        }

        var hospitalDto = _mapper.Map<HospitalDto>(hospital);

        // Doktorlar və xəstələr məlumatlarını yükləmək
        var doctors = await _unitOfWork.DoctorReadRepository.GetDoctorsByHospitalIdAsync(id);
        var patients = await _unitOfWork.PatientReadRepository.GetPatientsByHospitalIdAsync(id);

        hospitalDto.Doctors = _mapper.Map<ICollection<DoctorReadDto>>(doctors);
        hospitalDto.Patients = _mapper.Map<ICollection<PatientReadDto>>(patients);

        return hospitalDto;
    }

    public async Task UpdateHospitalAsync(HospitalUpdateDto hospitalUpdateDto)
    {
        var hospital = await _unitOfWork.HospitalReadRepository.GetByIdAsync(hospitalUpdateDto.Id);
        if (hospital == null)
        {
            throw new KeyNotFoundException("Hospital not found");
        }

        _mapper.Map(hospitalUpdateDto, hospital);
        await _unitOfWork.HospitalWriteRepository.SaveChangesAsync();
    }
}