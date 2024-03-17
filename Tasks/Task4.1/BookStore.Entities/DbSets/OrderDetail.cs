namespace BookStore.Entities.DbSets;

public class OrderDetail:AuditableEntity
{
   public Guid? OrderId { get; set; }
    public Order? Order { get; set; }

    public Guid BookId { get; set; }
    public Book Book { get; set; }

    public int Count { get; set; }
    public decimal TotalPriceForBooks { get; set; }


}
