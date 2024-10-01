using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Allergy;
using MediatR;

namespace EHospital.Application.Futures.Queries.Allergy.GetAllAllergies;

public class GetAllAllergiesQueryRequest : IRequest<GetAllAllergiesQueryResponse>
{
}
public class GetAllAllergiesQueryResponse
{
    public IEnumerable<AllergyReadDto> Allergies { get; set; }
}
public class GetAllAllergiesQueryHandler : IRequestHandler<GetAllAllergiesQueryRequest, GetAllAllergiesQueryResponse>
{
    private readonly IAllergyService _allergyService;

    public GetAllAllergiesQueryHandler(IAllergyService allergyService)
    {
        _allergyService = allergyService;
    }

    public async Task<GetAllAllergiesQueryResponse> Handle(GetAllAllergiesQueryRequest request, CancellationToken cancellationToken)
    {
        var allergies = await _allergyService.GetAllAllergiesAsync();
        return new GetAllAllergiesQueryResponse
        {
            Allergies = allergies
        };
    }
}


