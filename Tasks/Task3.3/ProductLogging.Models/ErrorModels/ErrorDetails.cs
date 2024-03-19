using System.Text.Json;

namespace ProductLogging.Models.ErrorModels;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

}
