using EHospital.Application.Futures.Commands.Hospital.Create;
using FluentValidation;

namespace EHospital.Application.Validators.Hospital;

public class HospitalCreateCommandRequestValidation : AbstractValidator<HospitalCreateCommandRequest>
{
    public HospitalCreateCommandRequestValidation()
    {
        RuleFor(c => c.HospitalCreateDto.Id).I
    }
}
