using BookStore.Core.Entities.Base;

namespace BookStore.Entities.DbSets;

public class Order: AuditableEntity
{
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    public int Count { get; set; }
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }

}
