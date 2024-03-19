namespace BookStore.Dal.Interface.Repositories;

public interface IRepositoryManager
{
    IAdminRepository AdminRepository { get; }
    IBookRepository BookRepository { get; }
    IOrderRepository OrderRepository { get; }
    ICustomerRepository CustomerRepository { get; }
    IOrderDetailRepository OrderDetailRepository { get; }

    Task SaveAsync();

}
