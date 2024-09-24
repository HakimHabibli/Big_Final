using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Hospital;
using MediatR;

namespace EHospital.Application.Futures.Queries.Hospital.GetHospitalDetails;

public class GetHospitalDetailsQueryRequest : IRequest<GetHospitalDetailsQueryResponse>
{
    public int HospitalId { get; set; }

}
public class GetHospitalDetailsQueryResponse
{
    public HospitalDto HospitalDto { get; set; }
}
public class GetHospitalDetailsQueryHandler : IRequestHandler<GetHospitalDetailsQueryRequest, GetHospitalDetailsQueryResponse>
{
    private readonly IHospitalService _hospitalService;

    public GetHospitalDetailsQueryHandler(IHospitalService hospitalService)
    {
        _hospitalService = hospitalService;
    }

    public async Task<GetHospitalDetailsQueryResponse> Handle(GetHospitalDetailsQueryRequest request, CancellationToken cancellationToken)
    {
        var hospitalDto = await _hospitalService.GetHospitalDetailsAsync(request.HospitalId);
        return new GetHospitalDetailsQueryResponse { HospitalDto = hospitalDto };
    }
}