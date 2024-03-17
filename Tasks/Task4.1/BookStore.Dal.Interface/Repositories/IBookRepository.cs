namespace BookStore.Dal.Interface.Repositories;

public interface IBookRepository:IAsyncRepository,IAsyncDeleteableRepository<Book>,IAsyncFindableRepository<Book>,
    IAsyncInsertableRepository<Book>,IAsyncOrderableRepository<Book>,
    IAsyncQueryableRepository<Book>,IAsyncUpdateableRepository<Book>
{
}
