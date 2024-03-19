namespace BookStore.Entities.DbSets;

public class Order: AuditableEntity
{
    public decimal TotalPrice { get; set; }
    public decimal PaidPrice { get; set; }
    public decimal DiscountRatio { get; set; }

    public Guid CustomerId { get; set; }

    public Customer Customer { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

}