namespace BookStore.Dal.EntityFramework.Repositories;

public class BookRepository:EFBaseRepository<Book>,IBookRepository
{
    public BookRepository(BookStoreDbContext context): base(context)    
    {
        
    }
}
