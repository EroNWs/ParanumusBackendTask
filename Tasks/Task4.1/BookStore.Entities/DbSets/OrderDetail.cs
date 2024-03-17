namespace BookStore.Entities.DbSets;

public class OrderDetail: AuditableEntity
{
   public Guid BookId { get; set; }

    public Book Book { get; set; }

    public int Count { get; set; }

    public double PaidPrice { get; set; }


}
