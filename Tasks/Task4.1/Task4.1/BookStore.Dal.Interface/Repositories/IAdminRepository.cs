namespace BookStore.Dal.Interface.Repositories;

public interface IAdminRepository : IAsyncRepository, IAsyncDeleteableRepository<Admin>, IAsyncFindableRepository<Admin>,
    IAsyncInsertableRepository<Admin>, IAsyncOrderableRepository<Admin>,
    IAsyncQueryableRepository<Admin>, IAsyncUpdateableRepository<Admin>
{
    Task<Admin?> GetByIdentityIdAsync(string identityId);

}
