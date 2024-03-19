namespace BookStore.Dtos.Orders;

public class OrderRequestDto
{
    public Guid CustomerId { get; set; }
    public List<OrderDto> Books { get; set; }
    public double TotalPrice { get; set; }

}
