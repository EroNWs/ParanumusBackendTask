using System.Text.Json.Serialization;

namespace BookStore.Shared.Dtos;

public class Response<T>
{
    public T Data { get; private set; }

    [JsonIgnore]
    public short StatusCode { get; private set; }

    [JsonIgnore]
    public bool IsSuccessful { get; private set; }

    public List<string> Errors { get; private set; }

    public static Response<T> Success(T data, short statusCode)
    {
        return new Response<T> { StatusCode = statusCode, Data = data, IsSuccessful = true };
    }

    public static Response<T> Success(short statusCode)
    {
        return new Response<T> { StatusCode = statusCode, Data = default(T), IsSuccessful = false };

    }

    public static Response<T> Fail(List<string> errors, short statusCode)
    {
        return new Response<T>
        {
            Errors = errors,
            StatusCode = statusCode,
            IsSuccessful = false
        };
    }

    public static Response<T> Fail(string error, short statusCode)
    {
        return new Response<T> { Errors = new List<string> { error }, StatusCode = statusCode, IsSuccessful = false };
    }

}
