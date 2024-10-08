using EHospital.Application.Dtos.Entites.Doctor;
using FluentValidation;

namespace EHospital.Application.Validators.Doctor;

public class DoctorCreateDtoValidator : AbstractValidator<DoctorCreateDto>
{
    public DoctorCreateDtoValidator()
    {
        RuleFor(d => d.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.");

        RuleFor(d => d.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.");

        RuleFor(d => d.Title)
            .NotEmpty().WithMessage("Title is required.");

        RuleFor(d => d.Specialization)
            .NotEmpty().WithMessage("Specialization is required.");

        RuleFor(d => d.ContactNumber)
            .NotEmpty().WithMessage("Contact number is required.");

        RuleFor(d => d.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email format is not valid.");

        RuleFor(d => d.Bio)
            .MaximumLength(500).WithMessage("Bio cannot exceed 500 characters.");

        RuleFor(d => d.HospitalId)
            .NotEmpty().WithMessage("Hospital Id is required.");

        RuleFor(d => d.Address)
            .NotEmpty().WithMessage("Hospital address is required");



    }
}
public class DoctorUpdateDtoValidator : AbstractValidator<DoctorUpdateDto>
{
    public DoctorUpdateDtoValidator()
    {
        RuleFor(d => d.Id)
            .GreaterThan(0).WithMessage("Doctor ID must be greater than zero.");

        RuleFor(d => d.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(2, 50).WithMessage("First name must be between 2 and 50 characters.");

        RuleFor(d => d.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Length(2, 50).WithMessage("Last name must be between 2 and 50 characters.");

        RuleFor(d => d.Title)
            .NotEmpty().WithMessage("Title is required.");

        RuleFor(d => d.Specialization)
            .NotEmpty().WithMessage("Specialization is required.");

        RuleFor(d => d.ContactNumber)
            .NotEmpty().WithMessage("Contact number is required.");

        RuleFor(d => d.Email)
            .NotEmpty().WithMessage("Email is required.");
        RuleFor(d => d.Address)
            .NotEmpty().WithMessage("Hospital address is required");

        RuleFor(d => d.Bio)
            .MaximumLength(500).WithMessage("Bio must not exceed 500 characters.");

        RuleFor(d => d.HospitalId)
            .NotEmpty().WithMessage("Hospital Id is required.");
    }
}
public class DoctorDeleteDtoValidator : AbstractValidator<DoctorDeleteDto>
{
    public DoctorDeleteDtoValidator()
    {
        RuleFor(d => d.Id)
            .GreaterThan(0).WithMessage("Doctor ID must be greater than zero.");
    }
}
