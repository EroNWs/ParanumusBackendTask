using BookStore.Dtos.Orders;

namespace BookStore.Business.Interfaces;

public interface IPurchaseService
{
    Task<OrderResponseDto> ProcessPurchaseAsync(OrderRequestDto request);

}
