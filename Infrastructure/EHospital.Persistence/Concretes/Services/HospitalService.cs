﻿using AutoMapper;
using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Dtos.Entites.Hospital;
using EHospital.Application.Dtos.Entites.Patient;
using EHospital.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Net.Http;
using System.Text.Json;

namespace EHospital.Application.Concretes.Services;


public class UploadedImageResponse
{
    public string FileName { get; set; }
}

public class HospitalService : IHospitalService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly HttpClient _httpClient;

    public HospitalService(IUnitOfWork unitOfWork, IMapper mapper, HttpClient httpClient)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _httpClient = httpClient;
    }

    public async Task CreateHospitalAsync(HospitalCreateDto hospitalCreateDto)
    {
        var hospital = _mapper.Map<Hospital>(hospitalCreateDto);

        if (hospitalCreateDto.ImageFile != null)
        {
            var content = new MultipartFormDataContent();
            string newFileName = null; 

            using (var ms = new MemoryStream())
            {
                await hospitalCreateDto.ImageFile.CopyToAsync(ms);
                var fileBytes = ms.ToArray();

                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(hospitalCreateDto.ImageFile.FileName);

                content.Add(new ByteArrayContent(fileBytes), "file", newFileName);
            }

            var response = await _httpClient.PostAsync("http://localhost:5217/images/upload", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Şəkili yükləmək mümkün olmadı.");
            }

           
            hospital.ImageUrl = newFileName; 
        }

        await _unitOfWork.HospitalWriteRepository.CreateAsync(hospital);
    }

    public async Task DeleteHospitalAsync(HospitalDeleteDto hospitalDeleteDto)
    {
        var hospital = await _unitOfWork.HospitalReadRepository.GetByIdAsync(hospitalDeleteDto.Id);

        if (hospital == null)
        {
            throw new KeyNotFoundException("Hospital not found.");
        }

        var fileName = hospital.ImageUrl;
        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
        var rootPath = Path.Combine(Directory.GetCurrentDirectory(), fileName); 

        
        if (!string.IsNullOrEmpty(fileName))
        {
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }

            if (File.Exists(rootPath))
            {
                File.Delete(rootPath);
            }
        }

       
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

       
        if (hospital == null)
        {
            throw new KeyNotFoundException("Hospital not found.");
        }

        return _mapper.Map<HospitalReadDto>(hospital);
    }


    public async Task<HospitalDto> GetHospitalDetailsAsync(int id)
    {
        var hospital = await _unitOfWork.HospitalReadRepository.GetByIdAsync(id, "Doctors", "Patients");

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

        // Burada ImageUrl dâhil ediləcək
        hospitalDto.ImageUrl = hospital.ImageUrl;

        return hospitalDto;
    }


    public async Task UpdateHospitalAsync(HospitalUpdateDto hospitalUpdateDto)
    {
        string newFileName=null;
        var hospital = await _unitOfWork.HospitalReadRepository.GetByIdAsync(hospitalUpdateDto.Id);
        if (hospital == null)
        {
            throw new KeyNotFoundException("Hospital not found");
        }

        if (!string.IsNullOrEmpty(hospital.ImageUrl))
        {
            var oldFileName = Path.GetFileName(hospital.ImageUrl);
            var deleteResponse = await _httpClient.DeleteAsync($"http://localhost:5217/images/delete/{oldFileName}");

            if (!deleteResponse.IsSuccessStatusCode)
            {
                throw new Exception("Köhnə şəkili silmək mümkün olmadı.");
            }
        }

        if (hospitalUpdateDto.ImageFile != null)
        {
            var content = new MultipartFormDataContent();
            using (var ms = new MemoryStream())
            {
                await hospitalUpdateDto.ImageFile.CopyToAsync(ms);
                var fileBytes = ms.ToArray();
                newFileName = Guid.NewGuid().ToString() + Path.GetExtension(hospitalUpdateDto.ImageFile.FileName);
                content.Add(new ByteArrayContent(fileBytes), "file", hospitalUpdateDto.ImageFile.FileName);
            }

            var uploadResponse = await _httpClient.PostAsync("http://localhost:5217/images/upload", content);

            if (!uploadResponse.IsSuccessStatusCode)
            {
                throw new Exception("Yeni şəkili yükləmək mümkün olmadı.");
            }
        }

        _mapper.Map(hospitalUpdateDto, hospital);
        hospital.ImageUrl = newFileName;
        await _unitOfWork.HospitalWriteRepository.UpdateAsync(hospital);
    }


}