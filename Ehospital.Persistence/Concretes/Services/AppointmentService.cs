using EHospital.Application.Abstractions.Repositories;
using EHospital.Application.Abstractions.Services;

namespace EHospital.Application.Concretes.Services;

public class AppointmentService : IAppointmentService 
{
    private readonly IAppointmentReadRepository _readRepo;
    private readonly IAppointmentWriteRepository _writeRepo;

    public AppointmentService(IAppointmentReadRepository readRepo, IAppointmentWriteRepository writeRepo)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
    }
}