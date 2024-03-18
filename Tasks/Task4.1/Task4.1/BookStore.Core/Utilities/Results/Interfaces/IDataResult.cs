namespace BookStore.Core.Utilities.Results.Interfaces;

public interface IDataResult<T> : IResult where T : class
{
    T Data { get; }
}
