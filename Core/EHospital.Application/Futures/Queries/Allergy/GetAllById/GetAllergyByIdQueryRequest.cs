using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Allergy;
using MediatR;

namespace EHospital.Application.Futures.Queries.Allergy.GetAllById;

//---------------------------------------------
public class GetAllergyByIdQueryRequest : IRequest<GetAllergyByIdQueryResponse>
{
    public int Id { get; set; }
}

public class GetAllergyByIdQueryResponse
{
    public AllergyReadDto Allergy { get; set; }
}
public class GetAllergyByIdQueryHandler : IRequestHandler<GetAllergyByIdQueryRequest, GetAllergyByIdQueryResponse>
{
    private readonly IAllergyService _allergyService;

    public GetAllergyByIdQueryHandler(IAllergyService allergyService)
    {
        _allergyService = allergyService;
    }

    public async Task<GetAllergyByIdQueryResponse> Handle(GetAllergyByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var allergy = await _allergyService.GetAllergyByIdAsync(request.Id);
        return new GetAllergyByIdQueryResponse
        {
            Allergy = allergy
        };
    }
}