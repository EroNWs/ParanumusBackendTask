namespace BookStore.Dal.Interface.Repositories;

public interface IOrderDetailRepository : IAsyncRepository, IAsyncDeleteableRepository<OrderDetail>, IAsyncFindableRepository<OrderDetail>,
    IAsyncInsertableRepository<OrderDetail>, IAsyncOrderableRepository<OrderDetail>,
    IAsyncQueryableRepository<OrderDetail>, IAsyncUpdateableRepository<OrderDetail>
{
}
