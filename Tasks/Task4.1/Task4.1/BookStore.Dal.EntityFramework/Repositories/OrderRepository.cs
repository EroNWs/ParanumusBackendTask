using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace BookStore.Dal.EntityFramework.Repositories;

public class OrderRepository:EFBaseRepository<Order>,IOrderRepository
{
    public OrderRepository(BookStoreDbContext context):base(context)
    {
        
    }

    public async Task<decimal> SumAsync(Expression<Func<Order, bool>> predicate, Expression<Func<Order, decimal>> selector)
    {
        return await _table.Where(predicate).Select(selector).SumAsync();
    }
}
