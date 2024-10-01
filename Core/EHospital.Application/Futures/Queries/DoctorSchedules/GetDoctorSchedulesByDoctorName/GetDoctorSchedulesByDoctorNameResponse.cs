using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Doctor;
using MediatR;

public class GetDoctorSchedulesByDoctorNameResponse
{
    public DoctorReadDto Doctor { get; set; }
    public string StatusCode { get; set; }
    public string Message { get; set; }
}


public class GetDoctorSchedulesByDoctorNameQuery : IRequest<GetDoctorSchedulesByDoctorNameResponse>
{
    public string DoctorName { get; set; }
}



public class GetDoctorSchedulesByDoctorNameQueryHandler : IRequestHandler<GetDoctorSchedulesByDoctorNameQuery, GetDoctorSchedulesByDoctorNameResponse>
{
    private readonly IDoctorSchedulesService _service;

    public GetDoctorSchedulesByDoctorNameQueryHandler(IDoctorSchedulesService service)
    {
        _service = service;
    }

    public async Task<GetDoctorSchedulesByDoctorNameResponse> Handle(GetDoctorSchedulesByDoctorNameQuery request, CancellationToken cancellationToken)
    {
        var response = new GetDoctorSchedulesByDoctorNameResponse();
        try
        {
            var doctorDto = await _service.GetDoctorSchedulesByDoctorNameAsync(request.DoctorName);
            if (doctorDto == null)
            {
                response.StatusCode = "404";
                response.Message = "Doctor not found";
                return response;
            }

            response.Doctor = doctorDto;
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
