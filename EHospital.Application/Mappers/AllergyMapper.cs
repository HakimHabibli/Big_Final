using AutoMapper;
using EHospital.Application.Dtos.Entites.Allergy;
using EHospital.Application.Dtos.Entites.Appointment;
using EHospital.Application.Dtos.Entites.ContactInfo;
using EHospital.Application.Dtos.Entites.Doctor;
using EHospital.Application.Dtos.Entites.DoctorSchedules;
using EHospital.Application.Dtos.Entites.EmergencyContact;
using EHospital.Application.Dtos.Entites.Hospital;
using EHospital.Application.Dtos.Entites.InsuranceDetails;
using EHospital.Application.Dtos.Entites.MedicalHistory;
using EHospital.Application.Dtos.Entites.Patient;
using EHospital.Application.Dtos.Entites.PatientDoctor;
using EHospital.Domain.Entities;

namespace EHospital.Application.Mappers;

public class AllergyMapper : Profile
{
    public AllergyMapper()
    {
        CreateMap<Allergy, AllergyDto>().ReverseMap();
        CreateMap<Allergy, AllergyCreateDto>().ReverseMap();
        CreateMap<Allergy, AllergyDeleteDto>().ReverseMap();
        CreateMap<Allergy, AllergyReadDto>().ReverseMap();
        CreateMap<Allergy, AllergyUpdateDto>().ReverseMap();
    }
}
public class AppointmentMapper : Profile
{
    public AppointmentMapper()
    {
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<Appointment, AppointmentCreateDto>().ReverseMap();
        CreateMap<Appointment, AppointmentReadDto>().ReverseMap();
        CreateMap<Appointment, AppointmentUpdateDto>().ReverseMap();
        CreateMap<Appointment, AppointmentDeleteDto>().ReverseMap();
    }
}
public class ContactInfoMapper : Profile
{
    public ContactInfoMapper()
    {
        CreateMap<ContactInfo, ContactInfoDto>().ReverseMap();
        CreateMap<ContactInfo, ContactInfoCreateDto>().ReverseMap();
        CreateMap<ContactInfo, ContactInfoDeleteDto>().ReverseMap();
        CreateMap<ContactInfo, ContactInfoReadDto>().ReverseMap();
        CreateMap<ContactInfo, ContactInfoUpdateDto>().ReverseMap();
    }
}
public class DoctorMapper : Profile
{
    public DoctorMapper()
    {
        CreateMap<Doctor, DoctorDto>().ReverseMap();
        CreateMap<Doctor, DoctorReadDto>().ReverseMap();
        CreateMap<Doctor, DoctorCreateDto>().ReverseMap();
        CreateMap<Doctor, DoctorDeleteDto>().ReverseMap();
        CreateMap<Doctor, DoctorUpdateDto>().ReverseMap();
    }
}
public class DoctorSchedulesMapper : Profile
{
    public DoctorSchedulesMapper()
    {
        CreateMap<DoctorSchedules, DoctorSchedulesDto>().ReverseMap();
        CreateMap<DoctorSchedules, DoctorSchedulesCreateDto>().ReverseMap();
        CreateMap<DoctorSchedules, DoctorSchedulesUpdateDto>().ReverseMap();
        CreateMap<DoctorSchedules, DoctorSchedulesDeleteDto>().ReverseMap();
        CreateMap<DoctorSchedules, DoctorSchedulesReadDto>().ReverseMap();
    }
}

public class EmergencyContactMapper : Profile
{
    public EmergencyContactMapper()
    {
        CreateMap<EmergencyContact, EmergencyContactDto>().ReverseMap();
        CreateMap<EmergencyContact, EmergencyContactReadDto>().ReverseMap();
        CreateMap<EmergencyContact, EmergencyContactDeleteDto>().ReverseMap();
        CreateMap<EmergencyContact, EmergencyContactCreateDto>().ReverseMap();
        CreateMap<EmergencyContact, EmergencyContactUpdateDto>().ReverseMap();
    }
}
public class HospitalMapper : Profile
{
    public HospitalMapper()
    {
        CreateMap<Hospital, HospitalDto>().ReverseMap();
        CreateMap<Hospital, HospitalCreateDto>().ReverseMap();
        CreateMap<Hospital, HospitalReadDto>().ReverseMap();
        CreateMap<Hospital, HospitalUpdateDto>().ReverseMap();
        CreateMap<Hospital, HospitalDeleteDto>().ReverseMap();
    }
}
public class InsuranceDetailsMapper : Profile
{
    public InsuranceDetailsMapper()
    {
        CreateMap<InsuranceDetails, InsuranceDetailsDto>().ReverseMap();
        CreateMap<InsuranceDetails, InsuranceDetailsCreateDto>().ReverseMap();
        CreateMap<InsuranceDetails, InsuranceDetailsReadDto>().ReverseMap();
        CreateMap<InsuranceDetails, InsuranceDetailsUpdateDto>().ReverseMap();
        CreateMap<InsuranceDetails, InsuranceDetailsDeleteDto>().ReverseMap();
    }
}
public class MedicalHistoryMapper : Profile
{
    public MedicalHistoryMapper()
    {
        CreateMap<MedicalHistory, MedicalHistoryDto>().ReverseMap();
        CreateMap<MedicalHistory, MedicalHistoryCreateDto>().ReverseMap();
        CreateMap<MedicalHistory, MedicalHistoryDeleteDto>().ReverseMap();
        CreateMap<MedicalHistory, MedicalHistoryReadDto>().ReverseMap();
        CreateMap<MedicalHistory, MedicalHistoryUpdateDto>().ReverseMap();
    }
}
public class PatientMapper : Profile
{
    public PatientMapper()
    {
        //TODO:Baxilacaq Action daxilinde nelere ehtiyac olsa 
        CreateMap<Patient, PatientDto>().ReverseMap();
        //CreateMap<Patient, PatientCreateDto>().ReverseMap();
        //CreateMap<Patient, PatientDto>().ReverseMap();
        //CreateMap<Patient, PatientDto>().ReverseMap();
        //CreateMap<Patient, PatientDto>().ReverseMap();
    }
}
public class PatientDoctorMapper : Profile
{
    public PatientDoctorMapper()
    {
        CreateMap<PatientDoctor, PatientDoctorDto>().ReverseMap();
        CreateMap<PatientDoctor, PatientDoctorCreateDto>().ReverseMap();
        CreateMap<PatientDoctor, PatientDoctorDeleteDto>().ReverseMap();
        CreateMap<PatientDoctor, PatientDoctorUpdateDto>().ReverseMap();
        CreateMap<PatientDoctor, PatientDoctorReadDto>().ReverseMap();
    }
}