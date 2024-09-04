namespace EHospital.Application.Dtos.Common;

public abstract class BaseAuditableEntityDto : BaseEntityDto
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
