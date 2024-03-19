namespace BookStore.Business.Services;

public class InMemoryDataStoreService : IInMemoryDataStoreService
{
    private readonly Dictionary<Guid, object> _dataStore = new Dictionary<Guid, object>();

    public void Add(Guid key, object data)
    {
        _dataStore[key] = data;
    }

    public object Get(Guid key)
    {
        _dataStore.TryGetValue(key, out var data);
        return data;
    }

    public void Update(Guid key, object newData)
    {
        if (_dataStore.ContainsKey(key))
        {
            _dataStore[key] = newData;
        }
        else
        {
            throw new KeyNotFoundException($"No data found for key: {key}");
        }
    }

    public bool Delete(Guid key)
    {
        return _dataStore.Remove(key);
    }

    public bool Exists(Guid key)
    {
        return _dataStore.ContainsKey(key);
    }
}