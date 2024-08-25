namespace EHospital.Domain.Common
{
    public abstract class BaseAuditableEntity : BaseEntity
    { 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}



