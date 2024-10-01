using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Allergy;
using MediatR;
namespace EHospital.Application.Futures.Commands.Allergy.Update;

public class AllergyDeleteCommandRequest : IRequest<AllergyDeleteCommandResponse>
{
    public AllergyDeleteDto AllergyDeleteDto { get; set; }
}
public class AllergyDeleteCommandResponse
{
    public string StatusCode { get; set; }
}
public class AllergyDeleteCommandHandler : IRequestHandler<AllergyDeleteCommandRequest, AllergyDeleteCommandResponse>
{
    private readonly IAllergyService _allergyService;

    public AllergyDeleteCommandHandler(IAllergyService allergyService)
    {
        _allergyService = allergyService;
    }

    public async Task<AllergyDeleteCommandResponse> Handle(AllergyDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new AllergyDeleteCommandResponse();

        await _allergyService.DeleteAllergyAsync(new AllergyDeleteDto { Id = request.AllergyDeleteDto.Id });
        response.StatusCode = "204"; // No Content

        return response;
    }
}
