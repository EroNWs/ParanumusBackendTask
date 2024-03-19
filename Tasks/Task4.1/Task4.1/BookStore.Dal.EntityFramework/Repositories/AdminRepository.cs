using Microsoft.EntityFrameworkCore;

namespace BookStore.Dal.EntityFramework.Repositories;

public class AdminRepository : EFBaseRepository<Admin>, IAdminRepository
{
    public AdminRepository(BookStoreDbContext context) : base(context) { }

    public Task<Admin?> GetByIdentityIdAsync(string identityId)
    {
        return _table.FirstOrDefaultAsync(x => x.IdentityId == identityId);

    }

}