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

    public async Task<IEnumerable<MedicalHistoryReadDto>> GetMedicalHistoriesBySerialNumberAsync(string serialNumber)
    {
        var patient = await _unitOfWork.PatientReadRepository.GetBySerialNumberAsync(serialNumber, true);

        if (patient == null)
            throw new KeyNotFoundException($"Patient with serial number {serialNumber} not found.");

        var medicalHistories = await _unitOfWork.MedicalHistoryReadRepository.GetByPatientIdAsync(patient.Id);

        if (medicalHistories == null || !medicalHistories.Any())
            throw new KeyNotFoundException($"Medical histories for patient {serialNumber} not found.");

        return _mapper.Map<IEnumerable<MedicalHistoryReadDto>>(medicalHistories);
    }



    public async Task<IEnumerable<MedicalHistoryReadDto>> GetAllMedicalHistoriesAsync()
    {
        var medicalHistories = await _unitOfWork.MedicalHistoryReadRepository.GetAllAsync(false,"Patient");
        

        return _mapper.Map<IEnumerable<MedicalHistoryReadDto>>(medicalHistories);
    }

    public async Task CreateMedicalHistoryAsync(MedicalHistoryCreateDto medicalHistoryCreateDto)
    {
        
        var patient = await _unitOfWork.PatientReadRepository.GetBySerialNumberAsync(medicalHistoryCreateDto.PatientSerialNumber);

        if (patient == null)
            throw new KeyNotFoundException($"Patient with serial number {medicalHistoryCreateDto.PatientSerialNumber} not found.");


        var medicalHistory = new MedicalHistory
        {
            PatientId = patient.Id, 
            Condition = medicalHistoryCreateDto.Condition,
            Treatment = medicalHistoryCreateDto.Treatment,
            Notes = medicalHistoryCreateDto.Notes,
            DiagnosisDate = medicalHistoryCreateDto.DiagnosisDate,
            
        };
        //var medicalHistory = _mapper.Map<MedicalHistory>(medicalHistoryCreateDto);


        medicalHistory.PatientId = patient.Id;

        
        await _unitOfWork.MedicalHistoryWriteRepository.CreateAsync(medicalHistory);
    }

    public async Task UpdateMedicalHistoryAsync(MedicalHistoryUpdateDto medicalHistoryUpdateDto)
    {
        
        var patient = await _unitOfWork.PatientReadRepository.GetBySerialNumberAsync(medicalHistoryUpdateDto.PatientSerialNumber);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with serial number {medicalHistoryUpdateDto.PatientSerialNumber} not found.");

        
        var medicalHistory = await _unitOfWork.MedicalHistoryReadRepository.GetByIdAsync(medicalHistoryUpdateDto.Id);
        if (medicalHistory == null)
            throw new KeyNotFoundException($"Medical history with ID {medicalHistoryUpdateDto.Id} not found.");

        
        
        medicalHistory.Condition = medicalHistoryUpdateDto.Condition;
        medicalHistory.Treatment = medicalHistoryUpdateDto.Treatment;
        medicalHistory.DiagnosisDate = medicalHistoryUpdateDto.DiagnosisDate;
        medicalHistory.Notes = medicalHistoryUpdateDto.Notes;
        medicalHistory.Patient.SerialNumber = medicalHistoryUpdateDto.PatientSerialNumber;
       
        await _unitOfWork.MedicalHistoryWriteRepository.UpdateAsync(medicalHistory);
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
