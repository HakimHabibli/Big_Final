using EHospital.Application.Abstractions;
using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Concretes.Repositories;
using EHospital.Persistence.Concretes.Repositories;
using EHospital.Persistence.DAL;

namespace EHospital.Persistence.Concretes;
//todo:Disponse ve Saavechange methodlarinin mentiqini anla sonra iclerini doldur +:)
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }


    #region Fields
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
    private IInsuranceDetailsReadRepository? _insuranceDetailsReadRepository;
    private IInsuranceDetailsWriteRepository? _insuranceDetailsWriteRepository;
    private IMedicalHistoryReadRepository? _medicalHistoryReadRepository;
    private IMedicalHistoryWriteRepository? _medicalHistoryWriteRepository;
    private IPatientReadRepository? _patientReadRepository;
    private IPatientWriteRepository? _patientWriteRepository;


    #endregion

    #region Repository
    public IAllergyReadRepository AllergyReadRepository => _allergyReadRepository ?? new AllergyReadRepository(_appDbContext);

    public IAllergyWriteRepository AllergyWriteRepository => _allergyWriteRepository ?? new AllergyWriteRepository(_appDbContext);

    public IAppointmentReadRepository AppointmentReadRepository => _appointmentReadRepository ?? new AppointmentReadRepository(_appDbContext);

    public IAppointmentWriteRepository AppointmentWriteRepository => _appointmentWriteRepository ?? new AppointmentWriteRepository(_appDbContext);

    public IContactInfoReadRepository ContactInfoReadRepository => _contactInfoReadRepository ?? new ContactInfoReadRepository(_appDbContext);

    public IContactInfoWriteRepository ContactInfoWriteRepository => _contactInfoWriteRepository ?? new ContactInfoWriteRepository(_appDbContext);

    public IDoctorReadRepository DoctorReadRepository => _doctorReadRepository ?? new DoctorReadRepository(_appDbContext);

    public IDoctorWriteRepository DoctorWriteRepository => _doctorWriteRepository ?? new DoctorWriteRepository(_appDbContext);

    public IDoctorSchedulesReadRepository DoctorSchedulesReadRepository => _doctorSchedulesReadRepository ?? new DoctorSchedulesReadRepository(_appDbContext);

    public IDoctorSchedulesWriteRepository DoctorSchedulesWriteRepository => _doctorSchedulesWriteRepository ?? new DoctorSchedulesWriteRepository(_appDbContext);

    public IEmergecyContactWriteRepository EmergecyContactWriteRepository => _emergecyContactWriteRepository ?? new EmergencyContactWriteRepository(_appDbContext);

    public IEmergencyContactReadRepository EmergencyContactReadRepository => _emergencyContactReadRepository ?? new EmergencyContactReadRepository(_appDbContext);
    public IHospitalReadRepository HospitalReadRepository => _hospitalReadRepository ?? new HospitalReadRepository(_appDbContext);

    public IHospitalWriteRepository HospitalWriteRepository => _hospitalWriteRepository ?? new HospitalWriteRepository(_appDbContext);
    public IInsuranceDetailsReadRepository InsuranceDetailsReadRepository => _insuranceDetailsReadRepository ?? new InsuranceDetailsReadRepository(_appDbContext);
    public IInsuranceDetailsWriteRepository InsuranceDetailsWriteRepository => _insuranceDetailsWriteRepository ?? new InsuranceDetailsWriteRepository(_appDbContext);

    public IMedicalHistoryReadRepository MedicalHistoryReadRepository => _medicalHistoryReadRepository ?? new MedicalHistoryReadRepository(_appDbContext);

    public IMedicalHistoryWriteRepository MedicalHistoryWriteRepository => _medicalHistoryWriteRepository ?? new MedicalHistoryWriteRepository(_appDbContext);
    public IPatientReadRepository PatientReadRepository => _patientReadRepository ?? new PatientReadRepository(_appDbContext);

    public IPatientWriteRepository PatientWriteRepository => _patientWriteRepository ?? new PatientWriteRepository(_appDbContext);

    #endregion

    //public void Dispose()
    //{
    //    throw new NotImplementedException();
    //}
    /*
     DbContext daxilində Savechage yazırıq bura Həmin methodu veririk
     */

    public async Task<int> SaveChangeAsync(CancellationToken cancellationToken)
    {
        return await _appDbContext.SaveChangesAsync();
    }


}
