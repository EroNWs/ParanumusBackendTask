namespace BookStore.Business.Interfaces;

public interface IInMemoryDataStoreService
{
    void Add(Guid key, object data);
    object Get(Guid key);
    void Update(Guid key, object newData);
    bool Delete(Guid key);
    bool Exists(Guid key);

}
