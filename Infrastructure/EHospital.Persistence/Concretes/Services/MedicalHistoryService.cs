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
        var patient = await _unitOfWork.PatientReadRepository.GetBySerialNumberAsync(serialNumber, true);
        //var patient = await _unitOfWork.PatientReadRepository.GetBySerialNumberAsync(serialNumber).AsNoTracking();

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
        // 1. Patient-in olub-olmadığını yoxla
        var patient = await _unitOfWork.PatientReadRepository.GetBySerialNumberAsync(medicalHistoryCreateDto.PatientSerialNumber);

        if (patient == null)
            throw new KeyNotFoundException($"Patient with serial number {medicalHistoryCreateDto.PatientSerialNumber} not found.");

        // 2. medicalHistoryCreateDto obyektini MedicalHistory obyektinə çevir
        //var medicalHistory = new MedicalHistory
        //{
        //    PatientId = patient.Id, // Patient ID-ni alırıq
        //    Condition = medicalHistoryCreateDto.Condition,
        //    Treatment = medicalHistoryCreateDto.Treatment,
        //    Notes = medicalHistoryCreateDto.Notes,
        //    DiagnosisDate = medicalHistoryCreateDto.DiagnosisDate,
        //    // Digər sahələr varsa, onları da buraya əlavə et
        //};
        var medicalHistory = _mapper.Map<MedicalHistory>(medicalHistoryCreateDto);

        // Assign the patient ID, since it's not part of the DTO but needs to be in the entity
        medicalHistory.PatientId = patient.Id;

        // 3. medicalHistory obyektini CreateAsync metodu ilə yaradılır
        await _unitOfWork.MedicalHistoryWriteRepository.CreateAsync(medicalHistory);
    }

    public async Task UpdateMedicalHistoryAsync(MedicalHistoryUpdateDto medicalHistoryUpdateDto)
    {
        // 1. Patient yoxlanışı
        var patient = await _unitOfWork.PatientReadRepository.GetBySerialNumberAsync(medicalHistoryUpdateDto.PatientSerialNumber);
        if (patient == null)
            throw new KeyNotFoundException($"Patient with serial number {medicalHistoryUpdateDto.PatientSerialNumber} not found.");

        // 2. MedicalHistory yoxlanışı
        var medicalHistory = await _unitOfWork.MedicalHistoryReadRepository.GetByIdAsync(medicalHistoryUpdateDto.Id);
        if (medicalHistory == null)
            throw new KeyNotFoundException($"Medical history with ID {medicalHistoryUpdateDto.Id} not found.");

        // 3. MedicalHistory obyektini yeniləmə
        // Manual mapping
        medicalHistory.Condition = medicalHistoryUpdateDto.Condition;
        medicalHistory.Treatment = medicalHistoryUpdateDto.Treatment;
        medicalHistory.DiagnosisDate = medicalHistoryUpdateDto.DiagnosisDate;
        medicalHistory.Notes = medicalHistoryUpdateDto.Notes;

        // 4. Dəyişiklikləri yadda saxla
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
