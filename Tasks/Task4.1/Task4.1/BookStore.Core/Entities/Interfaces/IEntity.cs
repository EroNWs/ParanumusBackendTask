using BookStore.Core.Enums;

namespace BookStore.Core.Entities.Interfaces;

public interface IEntity
{
    Guid Id { get; set; }
    Status Status { get; set; }

}
