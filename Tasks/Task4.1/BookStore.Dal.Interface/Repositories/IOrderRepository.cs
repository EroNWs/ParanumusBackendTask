namespace BookStore.Dal.Interface.Repositories;

public interface IOrderRepository : IAsyncRepository, IAsyncDeleteableRepository<Order>, IAsyncFindableRepository<Order>,
    IAsyncInsertableRepository<Order>, IAsyncOrderableRepository<Order>,
    IAsyncQueryableRepository<Order>, IAsyncUpdateableRepository<Order>
{
}
