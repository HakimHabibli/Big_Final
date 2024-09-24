using EHospital.Application.Dtos.Entites.DoctorSchedules;
using MediatR;

namespace EHospital.Application.Futures.Queries.DoctorSchedules;
public class GetAllDoctorSchedulesQueryRequest : IRequest<GetAllDoctorSchedulesQueryResponse> { }
public class GetAllDoctorSchedulesQueryResponse
{
    public IEnumerable<DoctorSchedulesReadDto> DoctorSchedulesReadDtos { get; set; }

}
//public class GetAllDoctorSchedulesQueryHandler : IRequestHandler<GetAllDoctorSchedulesQueryRequest, GetAllDoctorSchedulesQueryResponse>
//{
//    private readonly IDoctorSchedulesReadRepository _doctorSchedulesReadRepository;

//    public GetAllDoctorSchedulesQueryHandler(IDoctorSchedulesReadRepository doctorSchedulesReadRepository)
//    {
//        _doctorSchedulesReadRepository = doctorSchedulesReadRepository;
//    }

//    public async Task<GetAllDoctorSchedulesQueryResponse> Handle(GetAllDoctorSchedulesQueryRequest request, CancellationToken cancellationToken)
//    {
//        var schedules = await _doctorSchedulesReadRepository.GetAllAsync();
//        GetAllDoctorSchedulesQueryResponse response = new()
//        {
//            DoctorSchedulesReadDtos = schedules.Select(s => new DoctorSchedulesReadDto
//            {
//                Id = s.DoctorId,
//                Date = s.Date,
//                StartTime = s.StartTime,
//                EndTime = s.EndTime,
//                 = s.IsActive
//            }).ToList()
//        };

//        return response;
//    }
//}
