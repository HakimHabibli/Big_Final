using AutoMapper;
using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Dtos.Entites.Patient;
using EHospital.Domain.Entities;

namespace EHospital.Application.Concretes.Services;

public class DoctorService : IDoctorService
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DoctorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }




    public async Task<DoctorReadDto>? GetDoctorByIdAsync(int id)
    {
        var doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(id);
        return _mapper.Map<DoctorReadDto>(doctor);
    }

    public async Task<IEnumerable<DoctorReadDto>> GetAllDoctorsAsync()
    {
        var doctors = await _unitOfWork.DoctorReadRepository.GetAllAsync();
        return doctors.Select(d => _mapper.Map<DoctorReadDto>(d));
    }

    public async Task CreateDoctorAsync(DoctorCreateDto doctorCreateDTO)
    {
        var doctor = _mapper.Map<Doctor>(doctorCreateDTO);
        await _unitOfWork.DoctorWriteRepository.CreateAsync(doctor);
    }

    public async Task DeleteDoctorAsync(DoctorDeleteDto doctorDeleteDto)
    {
        var doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(doctorDeleteDto.Id);
        if (doctor == null)
        {
            throw new KeyNotFoundException("Doctor not found.");
        }

        await _unitOfWork.DoctorWriteRepository.DeleteAsync(doctor);

    }

    public async Task UpdateDoctorAsync(DoctorUpdateDto doctorUpdateDto)
    {
        var doctor = await _unitOfWork.DoctorReadRepository.GetByIdAsync(doctorUpdateDto.Id);
        if (doctor == null)
        {
            throw new Exception("Doctor not found");
        }

        var hospital = await _unitOfWork.HospitalReadRepository.GetByNameAsync(doctorUpdateDto.HospitalName);
        if (hospital == null) { throw new Exception("Hospital not found"); }

        doctor.HospitalId = hospital.Id;

        _mapper.Map(doctorUpdateDto, doctor);

        await _unitOfWork.DoctorWriteRepository.UpdateAsync(doctor);
    }

    public async Task<List<PatientDto>> GetAllPatientsAsync(int doctorId)
    {
        var patients = await _unitOfWork.DoctorReadRepository.GetPatientsByDoctorIdAsync(doctorId);
        return _mapper.Map<List<PatientDto>>(patients);
    }


}