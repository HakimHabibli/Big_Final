﻿using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Hospital;
using MediatR;

namespace EHospital.Application.Futures.Commands.Hospital.Create;

public class HospitalCreateCommandHandler : IRequestHandler<HospitalCreateCommandRequest, HospitalCreateCommandResponse>
{
    private readonly IHospitalService _hospitalService;

    public HospitalCreateCommandHandler(IHospitalService hospitalService)
    {
        _hospitalService = hospitalService;
    }

    public async Task<HospitalCreateCommandResponse> Handle(HospitalCreateCommandRequest request, CancellationToken cancellationToken)
    {
        HospitalCreateCommandResponse response = new HospitalCreateCommandResponse();
        await _hospitalService.CreateHospitalAsync(request.HospitalCreateDto);
        response.StatusCode = "201";

        return response;
    }
}
public class HospitalCreateCommandRequest : IRequest<HospitalCreateCommandResponse>
{
    public HospitalCreateDto HospitalCreateDto { get; set; }
}
public class HospitalCreateCommandResponse
{
    public string StatusCode { get; set; }
}
