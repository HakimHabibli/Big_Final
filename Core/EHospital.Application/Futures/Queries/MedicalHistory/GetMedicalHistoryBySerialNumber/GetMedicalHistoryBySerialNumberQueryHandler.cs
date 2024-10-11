using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.MedicalHistory;
using MediatR;

public class GetMedicalHistoryBySerialNumberQueryHandler : IRequestHandler<GetMedicalHistoryBySerialNumberQueryRequest, GetMedicalHistoryBySerialNumberQueryResponse>
{
    private readonly IMedicalHistoryService _medicalHistoryService;

    public GetMedicalHistoryBySerialNumberQueryHandler(IMedicalHistoryService medicalHistoryService)
    {
        _medicalHistoryService = medicalHistoryService;
    }

    public async Task<GetMedicalHistoryBySerialNumberQueryResponse> Handle(GetMedicalHistoryBySerialNumberQueryRequest request, CancellationToken cancellationToken)
    {
        var medicalHistory = await _medicalHistoryService.GetMedicalHistoriesBySerialNumberAsync(request.SerialNumber);

        if (medicalHistory == null)
        {
            throw new KeyNotFoundException($"No medical history found for patient with serial number {request.SerialNumber}");
        }

        return new GetMedicalHistoryBySerialNumberQueryResponse
        {
            MedicalHistoryReadDto = medicalHistory
        };
    }
}
public class GetMedicalHistoryBySerialNumberQueryRequest : IRequest<GetMedicalHistoryBySerialNumberQueryResponse>
{
    public string SerialNumber { get; set; }
}
public class GetMedicalHistoryBySerialNumberQueryResponse
{
    public IEnumerable<MedicalHistoryReadDto> MedicalHistoryReadDto { get; set; }
}
