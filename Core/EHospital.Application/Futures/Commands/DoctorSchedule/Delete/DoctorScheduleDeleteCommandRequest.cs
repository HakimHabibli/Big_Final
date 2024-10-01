using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using MediatR;

public class DoctorScheduleDeleteCommandRequest : IRequest<DoctorScheduleDeleteCommandResponse>
{
    public DoctorSchedulesDeleteDto doctorSchedulesDelete { get; set; }  // Assuming schedule ID is needed to delete the schedule
}

public class DoctorScheduleDeleteCommandResponse
{
    public string StatusCode { get; set; }
    public string Message { get; set; }
}

public class DoctorScheduleDeleteCommandHandler : IRequestHandler<DoctorScheduleDeleteCommandRequest, DoctorScheduleDeleteCommandResponse>
{
    private readonly IDoctorSchedulesService _service;

    public DoctorScheduleDeleteCommandHandler(IDoctorSchedulesService service)
    {
        _service = service;
    }

    public async Task<DoctorScheduleDeleteCommandResponse> Handle(DoctorScheduleDeleteCommandRequest request, CancellationToken cancellationToken)
    {
        var response = new DoctorScheduleDeleteCommandResponse();

        try
        {
            await _service.DeleteDoctorSchedulesAsync(new DoctorSchedulesDeleteDto { Id = request.doctorSchedulesDelete.Id });
            response.StatusCode = "200";
            response.Message = "Schedule deleted successfully";
        }
        catch (Exception ex)
        {
            response.StatusCode = "500";
            response.Message = ex.Message;
        }

        return response;
    }

}
