using EHospital.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;

public class ContactInfoMapping : BaseEntityMapping<ContactInfo>
{
    public override void Configure(EntityTypeBuilder<ContactInfo> builder)
    {
        base.Configure(builder);
        builder.HasKey(h => h.Id);

        #region Properties

        builder.Property(c => c.Email).HasMaxLength(255).IsRequired();
        builder.Property(c => c.Number).HasMaxLength(30).IsRequired();

        #endregion

        #region Relationships

        builder.HasOne(c => c.Patient)
               .WithOne(p => p.ContactInfo)
               .HasForeignKey<Patient>(p => p.ContactInfoId).OnDelete(DeleteBehavior.Cascade);
        #endregion

        #region Prop
        /*
            public string Email { get; set; }+
            public string Number { get; set; }+
            public int PatientId { get; set; }
            public Patient Patient { get; set; }
         */
        #endregion
    }
}
