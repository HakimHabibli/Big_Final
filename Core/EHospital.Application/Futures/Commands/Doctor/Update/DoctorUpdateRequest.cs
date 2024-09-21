using EHospital.Application.Dtos.Entites.Doctor;
using MediatR;

namespace EHospital.Application.Futures.Commands.Doctor.Update;

public class DoctorUpdateRequest : IRequest<DoctorUpdateResponse>
{
    public DoctorUpdateDto DoctorUpdateDto { get; set; }
}
