using AutoMapper;
using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.InsuranceDetails;
using EHospital.Application.Dtos.Entites.Patient;
using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Application.Concretes.Services;

public class PatientService : IPatientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreatePatientAsync(PatientDto patientDto)
    {
        var contactInfo = new ContactInfo
        {
            Number = patientDto.ContactInfo?.Number,
            Email = patientDto.ContactInfo?.Email
        };

        var emergencyContact = new EmergencyContact
        {
            Name = patientDto.EmergencyContact?.Name,
            Number = patientDto.EmergencyContact?.Number,
            Relationship = patientDto.EmergencyContact?.Relationship
        };

        var insuranceDetails = new InsuranceDetails
        {
            AdditionalInfo = patientDto.InsuranceDetails?.AdditionalInfo,
            CoverageStartDate = patientDto.InsuranceDetails.CoverageStartDate,
            CoverageEndDate = patientDto.InsuranceDetails.CoverageEndDate,
            InsuranceProvider = patientDto.InsuranceDetails?.InsuranceProvider,
            PlanType = patientDto.InsuranceDetails?.PlanType
        };

        var hospitalName = await _unitOfWork.HospitalReadRepository.GetByNameAsync(patientDto.HospitalName);
        if (hospitalName == null)
        {
            throw new Exception("Invalid Hospital Name, hospital not found.");
        }

        var patientEntity = new Patient
        {
            FirstName = patientDto.FirstName,
            LastName = patientDto.LastName,
            SerialNumber = patientDto.SerialNumber,
            Address = patientDto.Address,
            DateOfBirth = patientDto.DateOfBirth,
            Gender = patientDto.Gender,

            ContactInfo = contactInfo,
            EmergencyContact = emergencyContact,
            InsuranceDetails = insuranceDetails,
            HospitalName = hospitalName 
        };

        await _unitOfWork.PatientWriteRepository.CreateAsync(patientEntity);
    }

    public async Task DeletePatientAsync(int id)
    {
        var patient = await _unitOfWork.PatientReadRepository.GetByIdAsync(id);

        if (patient == null)
        {
            throw new Exception("Patient not found");
        }

        await _unitOfWork.PatientWriteRepository.DeleteAsync(patient);
    }

    public async Task<List<PatientReadDto>> GetAllPatients()
    {
        var patients = await _unitOfWork.PatientReadRepository
            .GetAllAsync(false, "ContactInfo", "EmergencyContact", "InsuranceDetails");

        if (patients == null || !patients.Any())
            throw new Exception("Patients not found");

        var patientsList = await patients.ToListAsync();

        List<PatientReadDto> patientsDto = _mapper.Map<List<PatientReadDto>>(patientsList);

        return patientsDto;
    }

    public async Task<PatientReadDto> GetPatientByIdAsync(int id)
    {
        var patient = await _unitOfWork.PatientReadRepository.GetByIdAsync(id,"ContactInfo", "EmergencyContact", "InsuranceDetails");

        if (patient == null)
          throw new Exception("Patient not found");

        return _mapper.Map<PatientReadDto>(patient);

    }

    public async Task<PatientReadDto> GetPatientBySerialNumberAsync(string serialNumber)
    {
        var patient = await _unitOfWork.PatientReadRepository.GetBySerialNumberAsync(serialNumber,false, "ContactInfo", "EmergencyContact", "InsuranceDetails", "MedicalHistory","Allergy");

        if (patient == null)
        {
            throw new Exception("Patient not found");
        }
        var medicalHistoriesCount = patient.MedicalHistories?.Count;
        var allergiesCount = patient.Allergies?.Count;
        return _mapper.Map<PatientReadDto>(patient);

    }

    public async Task UpdatePatientAsync(PatientDto patientDto)
    {
        var patient = await _unitOfWork.PatientReadRepository.GetByIdAsync(patientDto.Id);

        if (patient == null)
        {
            throw new Exception("Patient not found");
        }

        _mapper.Map(patientDto, patient); // Mövcud patient obyektini DTO ilə yeniləyirik
        await _unitOfWork.PatientWriteRepository.UpdateAsync(patient);

    }


}
