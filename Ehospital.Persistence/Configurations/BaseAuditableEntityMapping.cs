using EHospital.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EHospital.Configurations;

public class BaseAuditableEntityMapping<T> : BaseEntityMapping<T> where T : BaseAuditableEntity
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder); // BaseEntityMapping'den gelen yapılandırmaları uygular

        // CreatedAt ve UpdatedAt için default değerler ekleyin
        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("GETUTCDATE()") // SQL Server için UTC tarihini varsayılan değer olarak ayarlar
               .ValueGeneratedOnAdd(); // Yalnızca eklenirken değer oluşturur

        builder.Property(x => x.UpdatedAt)
               .HasDefaultValueSql("GETUTCDATE()") // SQL Server için UTC tarihini varsayılan değer olarak ayarlar
               .ValueGeneratedOnAddOrUpdate(); // Hem ekleme hem de güncelleme sırasında değer oluşturur
    }
}

