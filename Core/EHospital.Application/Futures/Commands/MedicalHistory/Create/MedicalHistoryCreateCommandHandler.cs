using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.MedicalHistory;
using MediatR;

namespace EHospital.Application.Futures.Commands.MedicalHistory.Create;

public class MedicalHistoryCreateCommandHandler : IRequestHandler<MedicalHistoryCreateCommandRequest, MedicalHistoryCreateCommandResponse>
{
    private readonly IMedicalHistoryService _medicalHistoryService;

    public MedicalHistoryCreateCommandHandler(IMedicalHistoryService medicalHistoryService)
    {
        _medicalHistoryService = medicalHistoryService;
    }

    public async Task<MedicalHistoryCreateCommandResponse> Handle(MedicalHistoryCreateCommandRequest request, CancellationToken cancellationToken)
    {
        MedicalHistoryCreateCommandResponse response = new MedicalHistoryCreateCommandResponse();
        await _medicalHistoryService.CreateMedicalHistoryAsync(request.MedicalHistoryCreateDto);
        response.StatusCode = "201";

        return response;
    }
}
public class MedicalHistoryCreateCommandResponse
{
    public string StatusCode { get; set; }
}
public class MedicalHistoryCreateCommandRequest : IRequest<MedicalHistoryCreateCommandResponse>
{
    public MedicalHistoryCreateDto MedicalHistoryCreateDto { get; set; }
}
