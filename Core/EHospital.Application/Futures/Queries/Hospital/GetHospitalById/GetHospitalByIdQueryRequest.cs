using MediatR;

namespace EHospital.Application.Futures.Queries.Hospital.GetHospitalById;

public class GetHospitalByIdQueryRequest : IRequest<GetHospitalByIdQueryResponse>
{
    public int Id { get; set; }
}
