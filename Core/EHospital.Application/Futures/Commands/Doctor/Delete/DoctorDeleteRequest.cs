using EHospital.Application.Dtos.Entites.Doctor;
using MediatR;

namespace EHospital.Application.Futures.Commands.Doctor.Delete;

public class DoctorDeleteRequest : IRequest<DoctorDeleteResponse>
{
    public DoctorDeleteDto DoctorDeleteDto { get; set; }
}