namespace BookStore.Dtos.Orders;

public class OrderDto
{
    public Guid BookId { get; set; }
    public int Count { get; set; }
}
