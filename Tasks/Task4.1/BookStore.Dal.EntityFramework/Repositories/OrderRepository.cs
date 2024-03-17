namespace BookStore.Dal.EntityFramework.Repositories;

public class OrderRepository:EFBaseRepository<Order>,IOrderRepository
{
    public OrderRepository(BookStoreDbContext context):base(context)
    {
        
    }
}
