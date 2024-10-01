using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Allergy;
using MediatR;
namespace EHospital.Application.Futures.Commands.Allergy.Update;

public class AllergyUpdateCommandRequest : IRequest<AllergyUpdateCommandResponse>
{
    public AllergyUpdateDto AllergyUpdateDto { get; set; }
}

public class AllergyUpdateCommandResponse
{
    public string StatusCode { get; set; }
}
public class AllergyUpdateCommandHandler : IRequestHandler<AllergyUpdateCommandRequest, AllergyUpdateCommandResponse>
{
    private readonly IAllergyService _allergyService;

    public AllergyUpdateCommandHandler(IAllergyService allergyService)
    {
        _allergyService = allergyService;
    }

    public async Task<AllergyUpdateCommandResponse> Handle(AllergyUpdateCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new AllergyUpdateCommandResponse();

        await _allergyService.UpdateAllergyAsync(request.AllergyUpdateDto);
        response.StatusCode = "204"; // No Content

        return response;
    }
}
