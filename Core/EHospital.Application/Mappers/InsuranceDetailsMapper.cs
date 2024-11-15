﻿
namespace EHospital.Application.Mappers;

public class InsuranceDetailsMapper : Profile
{
    public InsuranceDetailsMapper()
    {
        CreateMap<InsuranceDetails, InsuranceDetailsDto>().ReverseMap();
        CreateMap<InsuranceDetails, InsuranceDetailsCreateDto>().ReverseMap();
        CreateMap<InsuranceDetails, InsuranceDetailsReadDto>().ReverseMap();
        CreateMap<InsuranceDetails, InsuranceDetailsUpdateDto>().ReverseMap();
        CreateMap<InsuranceDetails, InsuranceDetailsDeleteDto>().ReverseMap();
    }
}

