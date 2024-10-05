using EHospital.Application.Dtos.Entites.Allergy;
using FluentValidation;

namespace EHospital.Application.Validators.Allergy;

public class AllergyCreateDtoValidator : AbstractValidator<AllergyCreateDto>
{
    public AllergyCreateDtoValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("Allergy name is required.")
            .Length(2, 100).WithMessage("Allergy name must be between 2 and 100 characters.");

        RuleFor(a => a.Details)
            .MaximumLength(500).WithMessage("Details cannot exceed 500 characters.");

        RuleFor(a => a.Severity)
            .IsInEnum().WithMessage("Severity must be a valid enum value.");

        RuleFor(a => a.PatientId)
            .GreaterThan(0).WithMessage("PatientId must be a positive integer.");
    }
}
public class AllergyDeleteDtoValidator : AbstractValidator<AllergyDeleteDto>
{
    public AllergyDeleteDtoValidator()
    {
        RuleFor(a => a.Id)
            .GreaterThan(0).WithMessage("Hospital ID must be greater than zero.");
    }
}
public class AllergyUpdateDtoValidator :
    AbstractValidator<AllergyUpdateDto>
{
    public AllergyUpdateDtoValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty().WithMessage("Allergy name is required.")
            .Length(2, 100).WithMessage("Allergy name must be between 2 and 100 characters.");

        RuleFor(a => a.Details)
            .MaximumLength(500).WithMessage("Details cannot exceed 500 characters.");

        RuleFor(a => a.Severity)
            .IsInEnum().WithMessage("Severity must be a valid enum value.");
    }
}
