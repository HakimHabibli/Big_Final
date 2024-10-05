using EHospital.Application.Futures.Commands.Hospital.Create;
using EHospital.Application.Futures.Commands.Hospital.Delete;
using EHospital.Application.Futures.Commands.Hospital.Update;
using FluentValidation;

namespace EHospital.Application.Validators.Hospital;

public class HospitalCreateCommandRequestValidation : AbstractValidator<HospitalCreateCommandRequest>
{
    public HospitalCreateCommandRequestValidation()
    {
        RuleFor(c => c.HospitalCreateDto.Name)
            .NotEmpty().WithMessage("Hospital name is required.")
            .Length(2, 100).WithMessage("Hospital name must be between 2 and 100 characters.");

        RuleFor(c => c.HospitalCreateDto.Address)
            .NotEmpty().WithMessage("Address is required.")
            .Length(5, 200).WithMessage("Address must be between 5 and 200 characters.");

        RuleFor(c => c.HospitalCreateDto.ContactNumber)
            .NotEmpty().WithMessage("Contact number is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Contact number must be a valid phone number.");

        RuleFor(c => c.HospitalCreateDto.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email format is not valid.");

        RuleFor(c => c.HospitalCreateDto.Description)
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
    }
}

public class HospitalDeleteCommandRequestValidation : AbstractValidator<HospitalDeleteCommandRequest>
{
    public HospitalDeleteCommandRequestValidation()
    {
        RuleFor(c => c.HospitalDeleteDto.Id)
            .GreaterThan(0).WithMessage("Hospital ID must be greater than zero.");
    }
}

public class HospitalUpdateCommandRequestValidation : AbstractValidator<HospitalUpdateCommandRequest>
{
    public HospitalUpdateCommandRequestValidation()
    {
        RuleFor(c => c.HospitalUpdateDto.Id)
            .GreaterThan(0).WithMessage("Hospital ID must be greater than zero.");

        RuleFor(c => c.HospitalUpdateDto.Name)
            .NotEmpty().WithMessage("Hospital Name is required.")
            .Length(2, 100).WithMessage("Hospital Name must be between 2 and 100 characters.");

        RuleFor(c => c.HospitalUpdateDto.Address)
            .NotEmpty().WithMessage("Address is required.")
            .Length(5, 200).WithMessage("Address must be between 5 and 200 characters.");

        RuleFor(c => c.HospitalUpdateDto.ContactNumber)
            .NotEmpty().WithMessage("Contact Number is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Contact Number must be a valid phone number.");

        RuleFor(c => c.HospitalUpdateDto.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be a valid email address.");

        RuleFor(c => c.HospitalUpdateDto.Description)
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
    }
}