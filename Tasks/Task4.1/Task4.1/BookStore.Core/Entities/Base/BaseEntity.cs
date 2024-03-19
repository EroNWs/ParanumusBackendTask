using BookStore.Core.Entities.Interfaces;
using BookStore.Core.Enums;

namespace BookStore.Core.Entities.Base;

public abstract class BaseEntity : ICreateableEntity
{
    public Guid Id { get; set; }
    public Status Status { get; set; }
    public string CreatedBy { get; set; } = null;
    public DateTime CreatedDate { get; set; }
    public string ModifiedBy { get; set; } = null;
    public DateTime ModifiedDate { get; set; }

    public BaseEntity()
    {
        CreatedDate = DateTime.UtcNow;
        ModifiedDate = DateTime.UtcNow;
        Status = Status.Active;
    }

}
