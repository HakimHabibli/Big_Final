using EHospital.Application.Dtos.Entites.Doctor;
using MediatR;

namespace EHospital.Application.Futures.Commands.Doctor.Create;

public class DoctorCreateRequest : IRequest<DoctorCreateResponse>//Requeste Response 
{
    public DoctorCreateDto DoctorCreateDto { get; set; }//request klasim
}
