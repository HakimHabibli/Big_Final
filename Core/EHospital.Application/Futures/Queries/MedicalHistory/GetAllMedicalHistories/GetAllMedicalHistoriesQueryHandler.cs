using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.MedicalHistory;
using MediatR;

public class GetAllMedicalHistoriesQueryHandler : IRequestHandler<GetAllMedicalHistoriesQueryRequest, GetAllMedicalHistoriesQueryResponse>
{
    private readonly IMedicalHistoryService _medicalHistoryService;

    public GetAllMedicalHistoriesQueryHandler(IMedicalHistoryService medicalHistoryService)
    {
        _medicalHistoryService = medicalHistoryService;
    }

    public async Task<GetAllMedicalHistoriesQueryResponse> Handle(GetAllMedicalHistoriesQueryRequest request, CancellationToken cancellationToken)
    {
        var medicalHistories = await _medicalHistoryService.GetAllMedicalHistoriesAsync();
        return new GetAllMedicalHistoriesQueryResponse
        {
            MedicalHistoryReadDtos = medicalHistories
        };
    }
}
public class GetAllMedicalHistoriesQueryRequest : IRequest<GetAllMedicalHistoriesQueryResponse>
{
}
public class GetAllMedicalHistoriesQueryResponse
{
    public IEnumerable<MedicalHistoryReadDto> MedicalHistoryReadDtos { get; set; }
}
