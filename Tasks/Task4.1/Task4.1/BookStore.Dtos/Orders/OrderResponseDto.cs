namespace BookStore.Dtos.Orders;

public class OrderResponseDto
{
    public double OriginalPrice { get; set; }
    public double DiscountAmount { get; set; }
    public double FinalPrice { get; set; }
}
