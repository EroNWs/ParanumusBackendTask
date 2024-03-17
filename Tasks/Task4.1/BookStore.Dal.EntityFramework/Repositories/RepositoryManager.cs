namespace BookStore.Dal.EntityFramework.Repositories;

public class RepositoryManager:IRepositoryManager
{
    private readonly BookStoreDbContext _context;

    private readonly Lazy<IAdminRepository> _adminRepository;
    private readonly Lazy<IBookRepository> _bookRepository;
    private readonly Lazy<ICustomerRepository> _customersRepository;
    private readonly Lazy<IOrderRepository> _ordersRepository;

    public RepositoryManager(BookStoreDbContext context)
    {
        _context= context;
        _adminRepository = new Lazy<IAdminRepository>(() => new AdminRepository(_context));
        _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
        _customersRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(_context));
        _ordersRepository = new Lazy<IOrderRepository>(() => new OrderRepository(_context));
    }

    public IAdminRepository AdminRepository => _adminRepository.Value;
    public IBookRepository BookRepository => _bookRepository.Value;
    public ICustomerRepository CustomerRepository => _customersRepository.Value;
    public IOrderRepository OrderRepository => _ordersRepository.Value;

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();  
    }


}
