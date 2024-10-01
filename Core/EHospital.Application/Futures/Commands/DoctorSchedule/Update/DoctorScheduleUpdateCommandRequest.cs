using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using MediatR;

public class DoctorScheduleUpdateCommandRequest : IRequest<DoctorScheduleUpdateCommandResponse>
{
    public DoctorSchedulesUpdateDto DoctorSchedulesUpdateDto { get; set; }
}

public class DoctorScheduleUpdateCommandResponse
{
    public string StatusCode { get; set; }
    public string Message { get; set; }
}

public class DoctorScheduleUpdateCommandHandler : IRequestHandler<DoctorScheduleUpdateCommandRequest, DoctorScheduleUpdateCommandResponse>
{
    private readonly IDoctorSchedulesService _service;

    public DoctorScheduleUpdateCommandHandler(IDoctorSchedulesService service)
    {
        _service = service;
    }

    public async Task<DoctorScheduleUpdateCommandResponse> Handle(DoctorScheduleUpdateCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new DoctorScheduleUpdateCommandResponse();

        try
        {
            await _service.UpdateDoctorSchedulesAsync(request.DoctorSchedulesUpdateDto);
            response.StatusCode = "200";
            response.Message = "Schedule updated successfully";
        }
        catch (Exception ex)
        {
            response.StatusCode = "500";
            response.Message = ex.Message;
        }

        return response;
    }
}
