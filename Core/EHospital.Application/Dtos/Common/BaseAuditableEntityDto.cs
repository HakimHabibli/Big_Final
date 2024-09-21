namespace EHospital.Application.Dtos.Common;

public abstract class BaseAuditableEntityDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
