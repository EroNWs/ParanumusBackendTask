var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/calculateaverage", (string numbers) =>
{
    try
    {
        var numberArray = numbers.Split(',').Select(int.Parse).ToArray();
        return Results.Ok(CalculateAverage(numberArray));
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch (FormatException)
    {
        return Results.BadRequest("Input array is not in the correct format. Please enter integers separated by commas.");
    }
});

double CalculateAverage(int[] numbers)
{
    if (numbers == null || numbers.Length == 0)
    {
        throw new ArgumentException("Array cannot be null or empty.");
    }

    double sum = 0;
    foreach (var number in numbers)
    {
        sum += number;
    }
    return sum / numbers.Length;
}

app.Run();
