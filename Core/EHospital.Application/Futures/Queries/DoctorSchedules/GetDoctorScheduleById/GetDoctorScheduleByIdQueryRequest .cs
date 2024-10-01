using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using MediatR;

public class GetDoctorScheduleByIdQueryRequest : IRequest<GetDoctorScheduleByIdQueryResponse>
{
    public int ScheduleId { get; set; }
}

public class GetDoctorScheduleByIdQueryResponse
{
    public DoctorSchedulesReadDto DoctorSchedule { get; set; }
    public string StatusCode { get; set; }
    public string Message { get; set; }
}

public class GetDoctorScheduleByIdQueryHandler : IRequestHandler<GetDoctorScheduleByIdQueryRequest, GetDoctorScheduleByIdQueryResponse>
{
    private readonly IDoctorSchedulesService _service;

    public GetDoctorScheduleByIdQueryHandler(IDoctorSchedulesService service)
    {
        _service = service;
    }

    public async Task<GetDoctorScheduleByIdQueryResponse> Handle(GetDoctorScheduleByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var response = new GetDoctorScheduleByIdQueryResponse();

        try
        {
            var schedule = await _service.GetDoctorSchedulesByIdAsync(request.ScheduleId);
            if (schedule == null)
            {
                response.StatusCode = "404";
                response.Message = "Schedule not found";
            }
            else
            {
                response.DoctorSchedule = schedule;
                response.StatusCode = "200";
            }
        }
        catch (Exception ex)
        {
            response.StatusCode = "500";
            response.Message = ex.Message;
        }

        return response;
    }
}
