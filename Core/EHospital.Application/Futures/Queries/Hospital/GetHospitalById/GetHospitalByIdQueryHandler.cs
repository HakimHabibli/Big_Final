using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Hospital;
using MediatR;

namespace EHospital.Application.Futures.Queries.Hospital.GetHospitalById;

public class GetHospitalByIdQueryHandler : IRequestHandler<GetHospitalByIdQueryRequest, GetHospitalByIdQueryResponse>
{
    private readonly IHospitalService _hospitalService;

    public GetHospitalByIdQueryHandler(IHospitalService hospitalService)
    {
        _hospitalService = hospitalService;
    }

    public async Task<GetHospitalByIdQueryResponse> Handle(GetHospitalByIdQueryRequest request, CancellationToken cancellationToken)
    {
        HospitalReadDto hospitalReadDto = await _hospitalService.GetHospitalByIdAsync(request.Id);
        GetHospitalByIdQueryResponse response = new() { HospitalReadDto = hospitalReadDto };
        return response;
    }
}
