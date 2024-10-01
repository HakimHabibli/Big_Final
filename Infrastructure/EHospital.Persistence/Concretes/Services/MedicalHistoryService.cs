using AutoMapper;
using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.MedicalHistory;
using EHospital.Domain.Entities;

namespace EHospital.Application.Concretes.Services;

public class MedicalHistoryService : IMedicalHistoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MedicalHistoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<MedicalHistoryReadDto> GetMedicalHistoryBySerialNumberAsync(string serialNumber)
    {
        var patient = await _unitOfWork.PatientReadRepository.GetBySerialNumberAsync(serialNumber);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with serial number {serialNumber} not found.");

        var medicalHistory = await _unitOfWork.MedicalHistoryReadRepository.GetByPatientIdAsync(patient.Id);
        if (medicalHistory == null)
            throw new KeyNotFoundException($"Medical history for patient {serialNumber} not found.");

        return _mapper.Map<MedicalHistoryReadDto>(medicalHistory);
    }

    public async Task<IEnumerable<MedicalHistoryReadDto>> GetAllMedicalHistoriesAsync()
    {
        var medicalHistories = await _unitOfWork.MedicalHistoryReadRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MedicalHistoryReadDto>>(medicalHistories);
    }

    public async Task CreateMedicalHistoryAsync(MedicalHistoryCreateDto medicalHistoryCreateDto)
    {
        var patient = await _unitOfWork.PatientReadRepository.GetBySerialNumberAsync(medicalHistoryCreateDto.PatientSerialNumber);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with serial number {medicalHistoryCreateDto.PatientSerialNumber} not found.");

        var medicalHistory = _mapper.Map<MedicalHistory>(medicalHistoryCreateDto);
        medicalHistory.PatientId = patient.Id;

        await _unitOfWork.MedicalHistoryWriteRepository.CreateAsync(medicalHistory);

    }

    public async Task UpdateMedicalHistoryAsync(MedicalHistoryUpdateDto medicalHistoryUpdateDto)
    {
        var patient = await _unitOfWork.PatientReadRepository.GetBySerialNumberAsync(medicalHistoryUpdateDto.PatientSerialNumber);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with serial number {medicalHistoryUpdateDto.PatientSerialNumber} not found.");

        var medicalHistory = await _unitOfWork.MedicalHistoryReadRepository.GetByIdAsync(medicalHistoryUpdateDto.Id);


    }

    public async Task DeleteMedicalHistoryAsync(MedicalHistoryDeleteDto medicalHistoryDeleteDto)
    {
        if (medicalHistoryDeleteDto == null || medicalHistoryDeleteDto.Id <= 0)
            throw new ArgumentException("Invalid MedicalHistoryDeleteDto", nameof(medicalHistoryDeleteDto));

        var medicalHistory = await _unitOfWork.MedicalHistoryReadRepository.GetByIdAsync(medicalHistoryDeleteDto.Id);

        if (medicalHistory == null)
            throw new KeyNotFoundException($"Medical history with ID {medicalHistoryDeleteDto.Id} not found.");

        await _unitOfWork.MedicalHistoryWriteRepository.DeleteAsync(medicalHistory);

    }
}
