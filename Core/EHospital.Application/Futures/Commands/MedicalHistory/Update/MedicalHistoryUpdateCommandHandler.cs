using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.MedicalHistory;
using MediatR;

namespace EHospital.Application.Futures.Commands.MedicalHistory.Update;

public class MedicalHistoryUpdateCommandHandler : IRequestHandler<MedicalHistoryUpdateCommandRequest, MedicalHistoryUpdateCommandResponse>
{
    private readonly IMedicalHistoryService _medicalHistoryService;

    public MedicalHistoryUpdateCommandHandler(IMedicalHistoryService medicalHistoryService)
    {
        _medicalHistoryService = medicalHistoryService;
    }

    public async Task<MedicalHistoryUpdateCommandResponse> Handle(MedicalHistoryUpdateCommandRequest request, CancellationToken cancellationToken)
    {
        MedicalHistoryUpdateCommandResponse response = new MedicalHistoryUpdateCommandResponse();

        await _medicalHistoryService.UpdateMedicalHistoryAsync(request.MedicalHistoryUpdateDto);

        response.StatusCode = "204"; // 204 No Content - Yeniləmə uğurla başa çatdı
        return response;
    }
}
public class MedicalHistoryUpdateCommandRequest : IRequest<MedicalHistoryUpdateCommandResponse>
{
    public MedicalHistoryUpdateDto MedicalHistoryUpdateDto { get; set; }
}
public class MedicalHistoryUpdateCommandResponse
{
    public string StatusCode { get; set; }
}
