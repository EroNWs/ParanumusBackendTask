namespace BookStore.Dal.Interface.Repositories;

public interface IRepositoryManager
{

    IAdminRepository AdminRepository { get; }

    IBookRepository BookRepository { get; }

    ICustomerRepository CustomerRepository { get; }

    IOrderDetailRepository OrderDetailRepository { get; }

    IOrderRepository OrderRepository { get; }

    Task SaveAsync();


}
