namespace BookStore.Dal.Interface.Repositories;

public interface IRepositoryManager
{

    IAdminRepository AdminRepository { get; }

    IBookRepository BookRepository { get; }

    ICustomerRepository CustomerRepository { get; }

    IOrderRepository OrderRepository { get; }

    IOrderDetailRepository OrderDetailRepository { get; }

    Task SaveAsync();


}
