using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Concretes.Repositories;
using EHospital.Persistence.DAL;

namespace EHospital.Persistence.Concretes;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    private IAllergyReadRepository? _allergyReadRepository;
    private IAllergyWriteRepository? _allergyWriteRepository;
    private IAppointmentReadRepository? _appointmentReadRepository;
    private IAppointmentWriteRepository? _appointmentWriteRepository;
    private IContactInfoReadRepository? _contactInfoReadRepository;
    private IContactInfoWriteRepository? _contactInfoWriteRepository;
    private IDoctorReadRepository? _doctorReadRepository;
    private IDoctorWriteRepository? _doctorWriteRepository;
    private IDoctorSchedulesReadRepository? _doctorSchedulesReadRepository;
    private IDoctorSchedulesWriteRepository? _doctorSchedulesWriteRepository;
    private IEmergecyContactWriteRepository? _emergecyContactWriteRepository;
    private IEmergencyContactReadRepository? _emergencyContactReadRepository;
    private IHospitalReadRepository? _hospitalReadRepository;
    private IHospitalWriteRepository? _hospitalWriteRepository;
    private IInsuranceDetailsReadRepository? _ınsuranceDetailsReadRepository;
    private IInsuranceDetailsWriteRepository? _ınsuranceDetailsWriteRepository;
    private IMedicalHistoryReadRepository? _medicalHistoryReadRepository;
    private IMedicalHistoryWriteRepository? _medicalHistoryWriteRepository;
    private IPatientReadRepository? _patientReadRepository;
    private IPatientWriteRepository? _patientWriteRepository;





    public IAllergyReadRepository AllergyReadRepository => _allergyReadRepository ??= new AllergyReadRepository(_appDbContext);

    public IAllergyWriteRepository AllergyWriteRepository => throw new NotImplementedException();

    public IAppointmentReadRepository AppointmentReadRepository => throw new NotImplementedException();

    public IAppointmentWriteRepository AppointmentWriteRepository => throw new NotImplementedException();

    public IContactInfoReadRepository ContactInfoReadRepository => throw new NotImplementedException();

    public IContactInfoWriteRepository ContactInfoWriteRepository => throw new NotImplementedException();

    public IDoctorReadRepository DoctorReadRepository => throw new NotImplementedException();

    public IDoctorWriteRepository DoctorWriteRepository => throw new NotImplementedException();

    public IDoctorSchedulesReadRepository DoctorSchedulesReadRepository => throw new NotImplementedException();

    public IDoctorSchedulesWriteRepository DoctorSchedulesWriteRepository => throw new NotImplementedException();

    public IEmergecyContactWriteRepository EmergecyContactWriteRepository => throw new NotImplementedException();

    public IEmergencyContactReadRepository EmergencyContactReadRepository => throw new NotImplementedException();

    public IHospitalReadRepository HospitalReadRepository => throw new NotImplementedException();

    public IHospitalWriteRepository HospitalWriteRepository => throw new NotImplementedException();

    public IInsuranceDetailsReadRepository InsuranceDetailsReadRepository => throw new NotImplementedException();

    public IInsuranceDetailsWriteRepository InsuranceDetailsWriteRepository => throw new NotImplementedException();

    public IMedicalHistoryReadRepository MedicalHistoryReadRepository => throw new NotImplementedException();

    public IMedicalHistoryWriteRepository MedicalHistoryWriteRepository => throw new NotImplementedException();

    public IPatientReadRepository PatientReadRepository => throw new NotImplementedException();

    public IPatientWriteRepository PatientWriteRepository => throw new NotImplementedException();




    public void Dispose()
    {
        throw new NotImplementedException();
    }


    /*
     DbContext daxilində Savechage yazırıq bura Həmin methodu veririk
     
     */

    public Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
