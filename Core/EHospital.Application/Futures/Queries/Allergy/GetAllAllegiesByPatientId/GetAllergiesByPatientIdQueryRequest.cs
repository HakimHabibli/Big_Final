using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Allergy;
using MediatR;

namespace EHospital.Application.Futures.Queries.Allergy.GetAllAllegiesByPatientId;

//-----------------------------------
public class GetAllergiesByPatientIdQueryRequest : IRequest<GetAllergiesByPatientIdQueryResponse>
{
    public int PatientId { get; set; }
}
public class GetAllergiesByPatientIdQueryResponse
{
    public IEnumerable<AllergyReadDto> Allergies { get; set; }
}
public class GetAllergiesByPatientIdQueryHandler : IRequestHandler<GetAllergiesByPatientIdQueryRequest, GetAllergiesByPatientIdQueryResponse>
{
    private readonly IAllergyService _allergyService;

    public GetAllergiesByPatientIdQueryHandler(IAllergyService allergyService)
    {
        _allergyService = allergyService;
    }

    public async Task<GetAllergiesByPatientIdQueryResponse> Handle(GetAllergiesByPatientIdQueryRequest request, CancellationToken cancellationToken)
    {
        var allergies = await _allergyService.GetAllergiesByPatientIdAsync(request.PatientId);
        return new GetAllergiesByPatientIdQueryResponse
        {
            Allergies = allergies
        };
    }
}