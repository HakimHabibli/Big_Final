using EHospital.Application.Dtos.Entites.Hospital;
using MediatR;

namespace EHospital.Application.Futures.Commands.Hospital.Create;

public class HospitalCreateCommandRequest : IRequest<HospitalCreateCommandResponse>
{
    public HospitalCreateDto HospitalCreateDto { get; set; }
}

