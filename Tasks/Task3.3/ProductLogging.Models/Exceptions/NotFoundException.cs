namespace ProductLogging.Models.Exceptions;

public abstract class NotFoundException:Exception
{
    protected NotFoundException(string message):base(message)
    {
        
    }

}

public sealed class ProductNotFoundException:NotFoundException
{
    public ProductNotFoundException(int id): base($"The Product with id : {id} Could not Found!")
    {
        
    }
}
