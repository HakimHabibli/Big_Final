using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using MediatR;

public class GetAllActiveDoctorSchedulesRequest : IRequest<GetAllActiveDoctorSchedulesResponse>
{
}

public class GetAllActiveDoctorSchedulesResponse
{
    public IEnumerable<DoctorSchedulesReadDto> Schedules { get; set; }
    public string StatusCode { get; set; }
    public string Message { get; set; }
}

public class GetAllActiveDoctorSchedulesQueryHandler : IRequestHandler<GetAllActiveDoctorSchedulesRequest, GetAllActiveDoctorSchedulesResponse>
{
    private readonly IDoctorSchedulesService _service;

    public GetAllActiveDoctorSchedulesQueryHandler(IDoctorSchedulesService service)
    {
        _service = service;
    }

    public async Task<GetAllActiveDoctorSchedulesResponse> Handle(GetAllActiveDoctorSchedulesRequest request, CancellationToken cancellationToken)
    {
        var response = new GetAllActiveDoctorSchedulesResponse();
        try
        {
            var schedulesDto = await _service.GetActiveDoctorSchedulesAsync();
            response.Schedules = schedulesDto;
            response.StatusCode = "200";
            return response;
        }
        catch (Exception ex)
        {
            response.StatusCode = "500";
            response.Message = ex.Message;
            return response;
        }
    }
}
