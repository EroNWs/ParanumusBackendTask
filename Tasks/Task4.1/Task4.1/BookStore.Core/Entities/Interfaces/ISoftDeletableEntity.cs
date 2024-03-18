namespace BookStore.Core.Entities.Interfaces;

public interface ISoftDeletableEntity : ICreateableEntity, IUpdateableEntity, IEntity
{
    string? DeletedBy { get; set; }

    DateTime? DateCreated { get; set; }

}
