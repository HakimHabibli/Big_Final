using EHospital.Application.Dtos.Entites.Hospital;
using MediatR;

namespace EHospital.Application.Futures.Commands.Hospital.Delete;

public class HospitalDeleteCommandRequest : IRequest<HospitalDeleteCommandResponse>
{
    public HospitalDeleteDto HospitalDeleteDto { get; set; }
}