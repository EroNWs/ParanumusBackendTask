namespace BookStore.Dal.EntityFramework.Repositories;

public class CustomerRepository:EFBaseRepository<Customer>,ICustomerRepository
{
    public CustomerRepository(BookStoreDbContext context):base(context)
    {
        
    }
}
