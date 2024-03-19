using System.Linq.Expressions;

namespace BookStore.Dal.Interface.Repositories;

public interface IOrderRepository : IAsyncRepository, IAsyncDeleteableRepository<Order>, IAsyncFindableRepository<Order>,
    IAsyncInsertableRepository<Order>, IAsyncOrderableRepository<Order>,
    IAsyncQueryableRepository<Order>, IAsyncUpdateableRepository<Order>
{
    Task<decimal> SumAsync(Expression<Func<Order, bool>> predicate, Expression<Func<Order, decimal>> selector);

}
