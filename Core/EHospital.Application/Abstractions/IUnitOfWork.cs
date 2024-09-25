using EHospital.Application.Abstractions.Repositories;

namespace EHospital.Application.Abstractions;

public interface IUnitOfWork
{
    IAllergyReadRepository AllergyReadRepository { get; }
    IAllergyWriteRepository AllergyWriteRepository { get; }
    IAppointmentReadRepository AppointmentReadRepository { get; }
    IAppointmentWriteRepository AppointmentWriteRepository { get; }
    IContactInfoReadRepository ContactInfoReadRepository { get; }
    IContactInfoWriteRepository ContactInfoWriteRepository { get; }
    IDoctorReadRepository DoctorReadRepository { get; }
    IDoctorWriteRepository DoctorWriteRepository { get; }
    IDoctorSchedulesReadRepository DoctorSchedulesReadRepository { get; }
    IDoctorSchedulesWriteRepository DoctorSchedulesWriteRepository { get; }
    IEmergecyContactWriteRepository EmergecyContactWriteRepository { get; }
    IEmergencyContactReadRepository EmergencyContactReadRepository { get; }
    IHospitalReadRepository HospitalReadRepository { get; }
    IHospitalWriteRepository HospitalWriteRepository { get; }
    IInsuranceDetailsReadRepository InsuranceDetailsReadRepository { get; }
    IInsuranceDetailsWriteRepository InsuranceDetailsWriteRepository { get; }
    IMedicalHistoryReadRepository MedicalHistoryReadRepository { get; }
    IMedicalHistoryWriteRepository MedicalHistoryWriteRepository { get; }
    IPatientReadRepository PatientReadRepository { get; }
    IPatientWriteRepository PatientWriteRepository { get; }

    Task<int> SaveChangeAsync(CancellationToken cancellationToken);
}
