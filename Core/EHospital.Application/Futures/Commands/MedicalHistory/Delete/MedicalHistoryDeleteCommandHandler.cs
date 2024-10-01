using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.MedicalHistory;
using MediatR;

namespace EHospital.Application.Futures.Commands.MedicalHistory.Delete;

public class MedicalHistoryDeleteCommandHandler : IRequestHandler<MedicalHistoryDeleteCommandRequest, MedicalHistoryDeleteCommandResponse>
{
    private readonly IMedicalHistoryService _medicalHistoryService;

    public MedicalHistoryDeleteCommandHandler(IMedicalHistoryService medicalHistoryService)
    {
        _medicalHistoryService = medicalHistoryService;
    }

    public async Task<MedicalHistoryDeleteCommandResponse> Handle(MedicalHistoryDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        MedicalHistoryDeleteCommandResponse response = new MedicalHistoryDeleteCommandResponse();
        await _medicalHistoryService.DeleteMedicalHistoryAsync(new MedicalHistoryDeleteDto { Id = request.MedicalHistoryDeleteDto.Id });
        response.StatusCode = "204"; // 204 No Content - silmə əməliyyatı uğurla başa çatdı

        return response;
    }
}
public class MedicalHistoryDeleteCommandRequest : IRequest<MedicalHistoryDeleteCommandResponse>
{
    public MedicalHistoryDeleteDto MedicalHistoryDeleteDto { get; set; }
}
public class MedicalHistoryDeleteCommandResponse
{
    public string StatusCode { get; set; }
}

