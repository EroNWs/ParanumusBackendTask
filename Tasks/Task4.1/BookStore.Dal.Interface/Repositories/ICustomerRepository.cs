namespace BookStore.Dal.Interface.Repositories;

public interface ICustomerRepository : IAsyncRepository, IAsyncDeleteableRepository<Customer>, IAsyncFindableRepository<Customer>,
    IAsyncInsertableRepository<Customer>, IAsyncOrderableRepository<Customer>,
    IAsyncQueryableRepository<Customer>, IAsyncUpdateableRepository<Customer>
{
}
