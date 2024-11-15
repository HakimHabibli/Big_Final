﻿using EHospital.Application.Abstractions.Services;
using EHospital.Application.Dtos.Entites.Appointment;
using EHospital.Application.Futures.Queries.AppUser.GetAllUserQuery;
using EHospital.Domain.Entities.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EHospital.Application.Futures.Queries.Appointment.GetAllAppointment;


public class GetAllAppointmentsQueryRequest : IRequest<GetAllAppointmentsQueryResponse>
{
}

public class GetAllAppointmentsQueryResponse
{
    public IEnumerable<AppointmentReadDto> Appointments { get; set; }
}

public class GetAllAppointmentsQueryHandler : IRequestHandler<GetAllAppointmentsQueryRequest, GetAllAppointmentsQueryResponse>
{
    private readonly IAppointmentService _appointmentService;

    public GetAllAppointmentsQueryHandler(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    public async Task<GetAllAppointmentsQueryResponse> Handle(GetAllAppointmentsQueryRequest request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentService.GetAllAppointmentAsync();
        return new GetAllAppointmentsQueryResponse
        {
            Appointments = appointments
        };
    }
}
