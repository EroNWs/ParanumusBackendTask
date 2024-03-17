namespace BookStore.Dal.EntityFramework.Repositories;

public class OrderDetailRepository : EFBaseRepository<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(BookStoreDbContext context):base(context)
    {
        
    }
}
