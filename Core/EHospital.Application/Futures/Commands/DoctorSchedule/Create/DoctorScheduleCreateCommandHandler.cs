using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using MediatR;

public class DoctorScheduleCreateCommandRequest : IRequest<DoctorScheduleCreateCommandResponse>
{
    public DoctorSchedulesCreateDto DoctorSchedulesCreateDto { get; set; }
}
public class DoctorScheduleCreateCommandResponse
{
    public string StatusCode { get; set; }
}
public class DoctorScheduleCreateCommandHandler : IRequestHandler<DoctorScheduleCreateCommandRequest, DoctorScheduleCreateCommandResponse>
{
    private readonly IDoctorSchedulesService _service;

    public DoctorScheduleCreateCommandHandler(IDoctorSchedulesService service)
    {
        _service = service;
    }

    public async Task<DoctorScheduleCreateCommandResponse> Handle(DoctorScheduleCreateCommandRequest request, CancellationToken cancellationToken)
    {
        DoctorScheduleCreateCommandResponse response = new();
        try
        {
            await _service.CreateDoctorSchedulesAsync(request.DoctorSchedulesCreateDto);
            response.StatusCode = "201";
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            response.StatusCode = "500";
        }
        return response;
    }
}
