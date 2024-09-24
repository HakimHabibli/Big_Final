using EHospital.Application.Dtos.Entites.Hospital;
using MediatR;

namespace EHospital.Application.Futures.Commands.Hospital.Update;

public class HospitalUpdateCommandRequest : IRequest<HospitalUpdateCommandResponse>
{
    public HospitalUpdateDto HospitalUpdateDto { get; set; }
}