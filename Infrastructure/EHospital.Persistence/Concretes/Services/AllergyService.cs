using AutoMapper;
using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Allergy;
using EHospital.Domain.Entities;

namespace EHospital.Application.Concretes.Services;

public class AllergyService : IAllergyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AllergyService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateAllergyAsync(AllergyCreateDto allergyCreateDto)
    {
        var allergy = _mapper.Map<Allergy>(allergyCreateDto);
        await _unitOfWork.AllergyWriteRepository.CreateAsync(allergy);
    }

    public async Task UpdateAllergyAsync(AllergyUpdateDto allergyUpdateDto)
    {
        var allergy = await _unitOfWork.AllergyReadRepository.GetByIdAsync(allergyUpdateDto.Id);
        if (allergy == null)
            throw new KeyNotFoundException($"Allergy with ID {allergyUpdateDto.Id} not found.");

        _mapper.Map(allergyUpdateDto, allergy);
        await _unitOfWork.AllergyWriteRepository.UpdateAsync(allergy);
    }

    public async Task DeleteAllergyAsync(AllergyDeleteDto allergyDeleteDto)
    {
        var allergy = await _unitOfWork.AllergyReadRepository.GetByIdAsync(allergyDeleteDto.Id);
        if (allergy == null)
            throw new KeyNotFoundException($"Allergy with ID {allergyDeleteDto.Id} not found.");

        await _unitOfWork.AllergyWriteRepository.DeleteAsync(allergy);
    }

    public async Task<IEnumerable<AllergyReadDto>> GetAllAllergiesAsync()
    {
        var allergies = await _unitOfWork.AllergyReadRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<AllergyReadDto>>(allergies);
    }

    public async Task<AllergyReadDto> GetAllergyByIdAsync(int id)
    {
        var allergy = await _unitOfWork.AllergyReadRepository.GetByIdAsync(id);
        if (allergy == null)
            throw new KeyNotFoundException($"Allergy with ID {id} not found.");

        return _mapper.Map<AllergyReadDto>(allergy);
    }

    public async Task<IEnumerable<AllergyReadDto>> GetAllergiesByPatientIdAsync(int patientId)
    {
        var allergies = await _unitOfWork.AllergyReadRepository.GetAllergiesByPatientIdAsync(patientId);
        return _mapper.Map<IEnumerable<AllergyReadDto>>(allergies);
    }


}

