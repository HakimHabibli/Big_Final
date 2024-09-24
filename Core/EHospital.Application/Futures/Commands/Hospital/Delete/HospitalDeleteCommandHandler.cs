using EHospital.Application.Abstractions.Services;
using MediatR;

namespace EHospital.Application.Futures.Commands.Hospital.Delete;

public class HospitalDeleteCommandHandler : IRequestHandler<HospitalDeleteCommandRequest, HospitalDeleteCommandResponse>
{
    private readonly IHospitalService _hospitalService;

    public HospitalDeleteCommandHandler(IHospitalService hospitalService)
    {
        _hospitalService = hospitalService;
    }

    public async Task<HospitalDeleteCommandResponse> Handle(HospitalDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        HospitalDeleteCommandResponse response = new HospitalDeleteCommandResponse();
        await _hospitalService.DeleteHospitalAsync(request.HospitalDeleteDto);
        response.StatusCode = "204";
        return response;
    }
}
