using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using MediatR;

public class GetAllDoctorSchedulesQueryRequest : IRequest<GetAllDoctorSchedulesQueryResponse>
{ }

public class GetAllDoctorSchedulesQueryResponse
{
    public IEnumerable<DoctorSchedulesReadDto> DoctorSchedules { get; set; }
    public string StatusCode { get; set; }
    public string Message { get; set; }
}

public class GetAllDoctorSchedulesQueryHandler : IRequestHandler<GetAllDoctorSchedulesQueryRequest, GetAllDoctorSchedulesQueryResponse>
{
    private readonly IDoctorSchedulesService _service;

    public GetAllDoctorSchedulesQueryHandler(IDoctorSchedulesService service)
    {
        _service = service;
    }

    public async Task<GetAllDoctorSchedulesQueryResponse> Handle(GetAllDoctorSchedulesQueryRequest request, CancellationToken cancellationToken)
    {
        var response = new GetAllDoctorSchedulesQueryResponse();

        try
        {
            var schedules = await _service.GetAllDoctorSchedulesAsync();
            response.DoctorSchedules = schedules;
            response.StatusCode = "200";
        }
        catch (Exception ex)
        {
            response.StatusCode = "500";
            response.Message = ex.Message;
        }

        return response;
    }
}
