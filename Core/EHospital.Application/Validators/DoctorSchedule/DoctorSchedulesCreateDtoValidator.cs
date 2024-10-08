using EHospital.Application.Dtos.Entites.DoctorSchedules;
using FluentValidation;

namespace EHospital.Application.Validators.DoctorSchedule;

public class DoctorSchedulesCreateDtoValidator : AbstractValidator<DoctorSchedulesCreateDto>
{
    public DoctorSchedulesCreateDtoValidator()
    {
        RuleFor(s => s.Date)
            .NotEmpty().WithMessage("Date is required.");
        //.Must(BeAValidDate).WithMessage("Date must be a valid date.");

        RuleFor(s => s.StartTime)
            .NotEmpty().WithMessage("Start time is required.");

        RuleFor(s => s.EndTime)
            .NotEmpty().WithMessage("End time is required.")
            .GreaterThan(s => s.StartTime).WithMessage("End time must be later than start time.");

        RuleFor(s => s.DoctorId)
            .GreaterThan(0).WithMessage("DoctorId must be a positive integer.");

        //RuleFor(s => s.Doctor)
        //    .NotEmpty().WithMessage("Doctor name is required.")
        //    .Length(2, 100).WithMessage("Doctor name must be between 2 and 100 characters.");
    }

    //private bool BeAValidDate(DateTime date)
    //{
    //    // Burada tarix keçmişə aid olmaması üçün 
    //    return date >= DateOnly.FromDateTime(DateTime.Now);
    //}
}
public class DoctorSchedulesUpdateDtoValidator : AbstractValidator<DoctorSchedulesUpdateDto>
{
    public DoctorSchedulesUpdateDtoValidator()
    {
        RuleFor(s => s.Date)
            .NotEmpty().WithMessage("Date is required.")
            .Must(BeAValidDate).WithMessage("Date must be a valid date.");

        RuleFor(s => s.StartTime)
            .NotEmpty().WithMessage("Start time is required.");

        RuleFor(s => s.EndTime)
            .NotEmpty().WithMessage("End time is required.")
            .GreaterThan(s => s.StartTime).WithMessage("End time must be later than start time.");

        RuleFor(s => s.DoctorId)
            .GreaterThan(0).WithMessage("DoctorId must be a positive integer.");

        RuleFor(s => s.Doctor)
            .NotNull().WithMessage("Doctor information is required.");
    }

    private bool BeAValidDate(DateOnly date)
    {
        return date >= DateOnly.FromDateTime(DateTime.Now);
    }
}

public class DoctorSchedulesDeleteDtoValidator : AbstractValidator<DoctorSchedulesDeleteDto>
{
    public DoctorSchedulesDeleteDtoValidator()
    {
        RuleFor(s => s.Id)
            .GreaterThan(0).WithMessage("Id must be a positive integer.");
    }
}
