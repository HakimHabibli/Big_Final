using EHospital.Application.Abstractions.Services;
using MediatR;

namespace EHospital.Application.Futures.Commands.Hospital.Update;

public class HospitalUpdateCommandHandler : IRequestHandler<HospitalUpdateCommandRequest, HospitalUpdateCommandResponse>
{
    private readonly IHospitalService _hospitalService;

    public HospitalUpdateCommandHandler(IHospitalService hospitalService)
    {
        _hospitalService = hospitalService;
    }

    public async Task<HospitalUpdateCommandResponse> Handle(HospitalUpdateCommandRequest request, CancellationToken cancellationToken)
    {
        HospitalUpdateCommandResponse response = new();
        await _hospitalService.UpdateHospitalAsync(request.HospitalUpdateDto);
        response.StatusCode = "204";

        return response;
    }
}
