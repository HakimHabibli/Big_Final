using EHospital.Application.Dtos.Entites.MedicalHistory;
using FluentValidation;

namespace EHospital.Application.Validators.MedicalHistory;

public class MedicalHistoryCreateDtoValidator : AbstractValidator<MedicalHistoryCreateDto>
{
    public MedicalHistoryCreateDtoValidator()
    {
        RuleFor(m => m.Condition)
            .NotEmpty().WithMessage("Condition is required.")
            .Length(2, 100).WithMessage("Condition must be between 2 and 100 characters.");

        RuleFor(m => m.DiagnosisDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Diagnosis date cannot be in the future.");

        RuleFor(m => m.Treatment)
            .NotEmpty().WithMessage("Treatment information is required.")
            .Length(2, 500).WithMessage("Treatment must be between 2 and 500 characters.");

        RuleFor(m => m.Notes)
            .MaximumLength(1000).WithMessage("Notes cannot exceed 1000 characters.");

        RuleFor(m => m.PatientSerialNumber)
            .NotEmpty().WithMessage("Patient serial number is required.")
            .Length(5, 50).WithMessage("Patient serial number must be between 5 and 50 characters.");
    }
}
public class MedicalHistoryUpdateDtoValidator : AbstractValidator<MedicalHistoryUpdateDto>
{
    public MedicalHistoryUpdateDtoValidator()
    {
        RuleFor(m => m.Condition)
            .NotEmpty().WithMessage("Condition is required.")
            .Length(2, 100).WithMessage("Condition must be between 2 and 100 characters.");

        RuleFor(m => m.DiagnosisDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Diagnosis date cannot be in the future.");

        RuleFor(m => m.Treatment)
            .NotEmpty().WithMessage("Treatment information is required.")
            .Length(2, 500).WithMessage("Treatment must be between 2 and 500 characters.");

        RuleFor(m => m.Notes)
            .MaximumLength(1000).WithMessage("Notes cannot exceed 1000 characters.");

        RuleFor(m => m.PatientSerialNumber)
            .NotEmpty().WithMessage("Patient serial number is required.")
            .Length(5, 50).WithMessage("Patient serial number must be between 5 and 50 characters.");
    }
}
public class MedicalHistoryDeleteDtoValidator : AbstractValidator<MedicalHistoryDeleteDto>
{
    public MedicalHistoryDeleteDtoValidator()
    {
        RuleFor(m => m.Id)
            .GreaterThan(0).WithMessage("Id must be a positive integer.");
    }
}
