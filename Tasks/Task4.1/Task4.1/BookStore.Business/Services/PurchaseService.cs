using BookStore.Business.Interfaces;
using BookStore.Dtos.Orders;
using BookStore.Entities.Enums;

namespace BookStore.Business.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IRepositoryManager _repositoryManager;

    public PurchaseService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<OrderResponseDto> ProcessPurchaseAsync(OrderRequestDto request)
    {
        var customer = await _repositoryManager.CustomerRepository.GetByIdAsync(request.CustomerId);

        var discountRate = CalculateDiscount(customer);

        double originalPrice = 0.0;
        List<OrderDetail> orderDetailsList = new List<OrderDetail>();
        foreach (var bookOrder in request.Books)
        {
            var book = await _repositoryManager.BookRepository.GetByIdAsync(bookOrder.BookId);

            if (book != null)
            {

                var totalPriceForBook = book.ListPrice * bookOrder.Count;

                OrderDetail orderDetail = new OrderDetail
                {
                    TotalPriceForBooks = (Decimal)totalPriceForBook,
                    BookId = bookOrder.BookId,
                    Count = bookOrder.Count

                };
                orderDetailsList.Add(orderDetail);
                await _repositoryManager.OrderDetailRepository.AddAsync(orderDetail);
                await _repositoryManager.OrderDetailRepository.SaveChangesAsync();

                originalPrice += book.ListPrice * bookOrder.Count;
            }
        }



        var discountAmount = originalPrice * discountRate;

        var finalPrice = originalPrice - discountAmount;


        var order = new Order
        {

            TotalPrice = (decimal)originalPrice,
            PaidPrice = (decimal)finalPrice,
            DiscountRatio = (decimal)discountAmount,
            CustomerId = customer.Id,
            OrderDetails = orderDetailsList

        };


        await _repositoryManager.OrderRepository.AddAsync(order);
        await _repositoryManager.OrderRepository.SaveChangesAsync();



        await UpdateCustomerRoleBasedOnSpending(request.CustomerId);

        return new OrderResponseDto
        {
            OriginalPrice = originalPrice,
            DiscountAmount = discountAmount,
            FinalPrice = finalPrice
        };

    }


    private double CalculateDiscount(Customer customer)
    {
        switch (customer.CustomerRole)
        {
            case CustomerRole.PremiumCustomer:
                return 0.10;
            case CustomerRole.CompanyEmployee:
                return 0.30;
            default:
                return 0.00;
        }
    }

    private async Task UpdateCustomerRoleBasedOnSpending(Guid customerId)
    {
        var customer = await _repositoryManager.CustomerRepository.GetByIdAsync(customerId);
        if (customer == null) return;

        var firstDayOfLastMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
        var lastDayOfLastMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);

        var totalSpendingLastMonth = await _repositoryManager.OrderRepository
            .SumAsync(
                o => o.CustomerId == customerId && o.CreatedDate >= firstDayOfLastMonth && o.CreatedDate <= lastDayOfLastMonth,
                o => o.TotalPrice
            );

        if (totalSpendingLastMonth > 100 && customer.CustomerRole != CustomerRole.CompanyEmployee)
        {
            customer.CustomerRole = CustomerRole.PremiumCustomer;
            await _repositoryManager.CustomerRepository.UpdateAsync(customer);
        }
    }


}
