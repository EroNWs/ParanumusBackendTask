namespace BookStore.Business.Services;

public class InMemoryDataStoreService : IInMemoryDataStoreService
{
  
    private readonly Dictionary<string, object> _dataStore = new Dictionary<string, object>();

    public void Add(string key, object data)
    {
        _dataStore[key] = data;
    }


}
