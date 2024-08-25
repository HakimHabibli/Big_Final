using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;

public class EmergencyContactMapping : BaseEntityMapping<EmergencyContact>
{
    public override void Configure(EntityTypeBuilder<EmergencyContact> builder)
    {
        base.Configure(builder);

        #region Properties
        builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
        builder.Property(e => e.Number).HasMaxLength(25).IsRequired();
        builder.Property(e => e.Relationship).HasMaxLength(60);
        #endregion

        #region Relationships
        builder.HasOne(e => e.Patient).WithOne(p => p.EmergencyContact).HasForeignKey<Patient>(e => e.EmergencyContactId);
        #endregion

        #region Prop
        /*
            public string Name { get; set; }+

            public string Number { get; set; }+

            public string Relationship { get; set; }+
            public Patient Patient { get; set; }
         */
        #endregion
    }
}
