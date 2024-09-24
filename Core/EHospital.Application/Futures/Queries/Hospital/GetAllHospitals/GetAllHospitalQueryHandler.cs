using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Hospital;
using MediatR;

namespace EHospital.Application.Futures.Queries.Hospital.GetAllHospitals;

public class GetAllHospitalQueryHandler : IRequestHandler<GetAllHospitalQueryRequest, GetAllHospitalQueryResponse>
{
    private readonly IHospitalService _hospitalService;

    public GetAllHospitalQueryHandler(IHospitalService hospitalService)
    {
        _hospitalService = hospitalService;
    }

    public async Task<GetAllHospitalQueryResponse> Handle(GetAllHospitalQueryRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<HospitalReadDto> hospitalReadDtos = await _hospitalService.GetAllHospitalsAsync();
        GetAllHospitalQueryResponse response = new() { HospitalReadDtos = hospitalReadDtos };
        return response;
    }
}
