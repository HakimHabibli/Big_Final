using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;

public class UserDeactivatedScheduleMapping : BaseEntityMapping<UserDeactivatedSchedule>
{
    public override void Configure(EntityTypeBuilder<UserDeactivatedSchedule> builder)
    {
        base.Configure(builder);
        builder.Property(p=>p.UserId);
        builder.Property(p=>p.DoctorScheduleId);
        builder.Property(p=>p.DeactivatedAt);
    }
}

