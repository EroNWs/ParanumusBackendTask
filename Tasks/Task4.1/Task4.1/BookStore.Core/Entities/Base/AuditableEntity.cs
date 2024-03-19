using BookStore.Core.Entities.Interfaces;

namespace BookStore.Core.Entities.Base;

public abstract class AuditableEntity : BaseEntity, ISoftDeletableEntity
{
    public AuditableEntity()
    {
        DateCreated = DateTime.UtcNow;
    }
    public string? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
    public DateTime? DateCreated { get; set; }
}
