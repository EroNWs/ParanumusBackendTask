namespace BookStore.Business.Interfaces;

public interface IInMemoryDataStoreService
{
    void Add(string key, object data);

}
