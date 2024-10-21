using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using MediatR;

public class GetActiveDoctorSchedulesQuery : IRequest<List<ActiveDoctorScheduleReadDto>>
{
}
public class GetActiveDoctorSchedulesQueryHandler : IRequestHandler<GetActiveDoctorSchedulesQuery, List<ActiveDoctorScheduleReadDto>>
{
    private readonly IUserDeactivatedScheduleService _userDeactivatedScheduleService;

    public GetActiveDoctorSchedulesQueryHandler(IUserDeactivatedScheduleService userDeactivatedScheduleService)
    {
        _userDeactivatedScheduleService = userDeactivatedScheduleService;
    }

    public async Task<List<ActiveDoctorScheduleReadDto>> Handle(GetActiveDoctorSchedulesQuery request, CancellationToken cancellationToken)
    {
        return await _userDeactivatedScheduleService.GetActiveDoctorSchedulesAsync();
    }
}

